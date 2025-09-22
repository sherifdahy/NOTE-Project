
using Azure.Core;
using ETA.Consume.Contracts.Auth.Requests;
using ETA.Consume.Contracts.Receipt.Requests;
using ETA.Consume.Contracts.Receipt.Responses;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NOTE.Solutions.API.Extensions;
using NOTE.Solutions.BLL.Contracts.Document.Requests;
using NOTE.Solutions.BLL.Contracts.Document.Responses;
using NOTE.Solutions.Entities.Entities.Address;
using NOTE.Solutions.Entities.Entities.Company;
using NOTE.Solutions.Entities.Entities.Document;

namespace NOTE.Solutions.BLL.Services;

public class ReceiptService : IReceiptService
{
    private readonly ETA.Consume.Interfaces.IEtaManager _etaManager;
    private readonly ILogger<ReceiptService> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ReceiptService
        (ILogger<ReceiptService> logger, 
        IHttpContextAccessor httpContextAccessor,
        ICacheService cacheService,
        IUnitOfWork unitOfWork, 
        ETA.Consume.Interfaces.IEtaManager etaManager)
    {
        _logger = logger;
        _etaManager = etaManager;
        _unitOfWork = unitOfWork;
        _cacheService = cacheService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Result<DocumentResponse>> CreateAsync(int branchId, int activeCodeId, int posId, DocumentRequest documentRequest, CancellationToken cancellationToken = default)
    {
        #region validation
        if (!_unitOfWork.Branches.IsExist(x => x.Id == branchId))
            return Result.Failure<DocumentResponse>(BranchErrors.NotFound);

        if (!_unitOfWork.DocumentTypes.IsExist(x => x.Id == documentRequest.DocumentTypeId))
            return Result.Failure<DocumentResponse>(DocumentTypeErrors.NotFound);

        if (!_unitOfWork.Branches.IsExist(x => (x.Id == branchId) && (x.POSs.Any(x => x.Id == posId))))
            return Result.Failure<DocumentResponse>(POSErrors.NotFound);

        foreach (var documentDetails in documentRequest.DocumentDetails)
        {
            if (!_unitOfWork.ProductUnits.IsExist(x => x.Id == documentDetails.ProductUnitId))
                return Result.Failure<DocumentResponse>(ProductUnitErrors.NotFound);
        }
        #endregion

        var document = documentRequest.Adapt<Document>();
        document.BranchId = branchId;

        await _unitOfWork.Documents.AddAsync(document, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);


        string cacheKey = $"cached-receipt-for-branch-{branchId}";

        await _cacheService.RemoveAsync(cacheKey);

        return Result.Success(document.Adapt<DocumentResponse>());

    }
    
    public Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public async Task<Result<IEnumerable<DocumentResponse>>> GetAllAsync(int branchId,CancellationToken cancellationToken = default)
    {
        if (!_unitOfWork.Branches.IsExist(x => x.Id == branchId))
            return Result.Failure<IEnumerable<DocumentResponse>>(BranchErrors.NotFound);

        string cacheKey = $"cached-receipt-for-branch-{branchId}";

        var cachedReceipts = await _cacheService.GetAsync<IEnumerable<DocumentResponse>>(cacheKey, cancellationToken);

        if(cachedReceipts is not null)
            return Result.Success(cachedReceipts);

        var documents = await _unitOfWork.Documents.FindAllAsync(x=>x.BranchId == branchId,cancellationToken: cancellationToken);

        var receipts = documents.Adapt<IEnumerable<DocumentResponse>>();

        await _cacheService.SetAsync(cacheKey, receipts, TimeSpan.FromDays(10));

        return Result.Success(receipts);
    }
    public Task<Result<DocumentResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<Result> UpdateAsync(DocumentRequest documentRequest, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    
    #region Helper
    private async Task<Result<string>> GetAccessTokenAsync(int posId)
    {
        int customerId = _httpContextAccessor.HttpContext!.User.GetUserId();

        var cacheKey = $"cached-access-token/posId/{posId}";

        var accessToken = await _cacheService.GetAsync<string>(cacheKey);

        if (accessToken is not null)
            return Result.Success(accessToken);

        var pos = await _unitOfWork.POSs.FindAsync(x => x.Id == posId);

        if (pos is null)
            return Result.Failure<string>(POSErrors.NotFound);

        var authPosRequest = new AuthPOSRequest()
        {
            ClientId = pos!.ClientId,
            ClientSecret = pos.ClientSecret,
            POSSerial = pos.POSSerial,
        };

        var result = await _etaManager.EtaAuthService.AuthenticatePOSAsync(authPosRequest);

        if (!result.IsSuccess)
            return Result.Failure<string>(new Error("", JsonConvert.SerializeObject(result.Error), result.StatusCode));

        await _cacheService.SetAsync<string>(cacheKey, result.Data!.AccessToken, TimeSpan.FromSeconds(result.Data.ExpiresIn));

        return Result.Success(result.Data.AccessToken);
    }
    private async Task<Result> SubmitAsync(int posId, int activeCodeId, Document document)
    {
        var accessTokenResult = await GetAccessTokenAsync(posId);

        if (!accessTokenResult.IsSuccess)
        {

        }

        var pos = await _unitOfWork.POSs.FindAsync(x => x.Id == posId, new string[]
        {
            nameof(POS.Branch),
            $"{nameof(POS.Branch)}.{nameof(POS.Branch.Company)}",
            $"{nameof(POS.Branch)}.{nameof(POS.Branch.Company)}.{nameof(Company.CompanyActiveCodes)}",
            $"{nameof(POS.Branch)}.{nameof(POS.Branch.Company)}.{nameof(Company.CompanyActiveCodes)}",
            $"{nameof(POS.Branch)}.{nameof(POS.Branch.City)}",
            $"{nameof(POS.Branch)}.{nameof(POS.Branch.City)}.{nameof(City.Governorate)}",
            $"{nameof(POS.Branch)}.{nameof(POS.Branch.City)}.{nameof(City.Governorate)}.{nameof(Governorate.Country)}",
        });

        if (pos is null)
            return Result.Failure<SubmitReceiptsResponse>(POSErrors.NotFound);

        var documents = new SubmitReceiptsRequest()
        {
            Receipts = [new SubmitReceiptRequest(){
                Header = new ETA.Consume.Contracts.Header.Requests.HeaderRequest()
                {
                    DateTimeIssued = document.Header.DateTime,
                    Currency = "EGP",
                    ExchangeRate = 0,
                    ReceiptNumber = document.Header.DocumentNumber,

                },
                DocumentType = new ETA.Consume.Contracts.DocumentType.Requests.DocumentTypeRequest()
                {
                    ReceiptType = document.DocumentType.Type,
                    TypeVersion = document.DocumentType.Version
                },
                Seller = new ETA.Consume.Contracts.Seller.Requests.SellerRequest()
                {
                    CompanyTradeName = pos.Branch.Company.Name,
                    DeviceSerialNumber = pos.POSSerial,
                    ActivityCode = pos.Branch.Company.CompanyActiveCodes.First(x=>x.ActiveCodeId == activeCodeId).ActiveCode.Code,
                    BranchCode  = pos.Branch.Code,
                    RIN = pos.Branch.Company.RIN,
                    BranchAddress = new ETA.Consume.Contracts.BranchAddress.Requests.BranchAddressRequest()
                    {
                        Country = pos.Branch.City.Governorate.Country.Code,
                        Governate = pos.Branch.City.Governorate.Name,
                        RegionCity = pos.Branch.City.Code,
                        BuildingNumber = pos.Branch.BuildingNumber,
                        Street = pos.Branch.Street,
                    },
                },
                Buyer = new ETA.Consume.Contracts.Buyer.Requests.BuyerRequest()
                {
                    Id = document.Buyer.SSN,
                    Name = document.Buyer.Name,
                    //MobileNumber = document.Buyer,
                    Type = document.Buyer.Type.ToString(),
                },
                ItemData = document.DocumentDetails.Select(d => new ETA.Consume.Contracts.Item.Requests.ItemRequest()
                {
                    InternalCode = d.ProductUnit.InternalCode,
                    Description = d.ProductUnit.Description,
                    ItemType = d.ProductUnit.GlobalCodeType.ToString(),
                    Quantity = d.Quantity,
                    UnitType = d.ProductUnit.Unit!.Code,
                    UnitPrice = d.UnitPrice,
                    ItemCode = d.ProductUnit.GlobalCode,
                    TotalSale = d.Quantity * d.UnitPrice,
                    NetSale = d.Quantity * d.UnitPrice,
                    Total = d.Quantity * d.UnitPrice,
                }).ToList(),
                TotalSales = document.DocumentDetails.Sum(d => d.Quantity * d.UnitPrice),
                NetAmount = document.DocumentDetails.Sum(d => d.Quantity * d.UnitPrice),
                TotalAmount = document.DocumentDetails.Sum(d => d.Quantity * d.UnitPrice),
                PaymentMethod = document.PaymentMethod.ToString(),
            }]
        };

        var submitResult = await _etaManager.ReceiptService.SubmitReceiptsAsync(accessTokenResult.Value, documents);

        if (!submitResult.IsSuccess)
            return Result.Failure<SubmitReceiptsResponse>(new Error(submitResult.StatusCode.ToString(), submitResult.Error.Error, submitResult.StatusCode));

        BackgroundJob.Schedule(() =>
            CheckStatusAsync(submitResult.Data!.SubmissionId, accessTokenResult.Value), TimeSpan.FromSeconds(10)
        );

        return Result.Success(submitResult.Data!);
    }
    private async Task CheckStatusAsync(string subuuid, string token)
    {
        var result = await _etaManager.ReceiptService.GetReceiptSubmission(subuuid, token);

        if (!result.IsSuccess)
            return;

        switch (result.Data?.Status)
        {

            case "Valid":
            case "Invalid":
                _logger.LogWarning(result.Data.Status);
                break;

            case "InProgress":
            default:
                _logger.LogWarning(result.Data!.Status);
                BackgroundJob.Schedule(() => CheckStatusAsync(subuuid, token), TimeSpan.FromSeconds(10));
                break;
        }
    } 
    #endregion
}

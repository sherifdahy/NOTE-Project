using ETA.Consume.Contracts.Auth.Requests;
using ETA.Consume.Contracts.Receipt.Requests;
using ETA.Consume.Contracts.Receipt.Responses;
using ETA.Consume.Interfaces;
using Newtonsoft.Json;
using NOTE.Solutions.Entities.Entities.Document;

namespace NOTE.Solutions.BLL.Services;

public class ETAService : IETAService
{
    private readonly IEtaManager _etaManager;
    private readonly ICacheService _cacheService;
    public ETAService(IEtaManager etaManager,ICacheService cacheService)
    {
        _etaManager = etaManager;
        _cacheService = cacheService;
    }
    public async Task<Result<string>> GetTokenAsync(AuthPOSRequest request)
    {
        var accessToken = await _cacheService.GetAsync<string>(request.ClientId);

        if(accessToken == null)
        {
            var result = await _etaManager.EtaAuthService.AuthenticatePOSAsync(request);

            if (!result.IsSuccess)
                return Result.Failure<string>(new Error("", JsonConvert.SerializeObject(result.Error), result.StatusCode));

            await _cacheService.SetAsync<string>(request.ClientId,result.Data!.AccessToken,TimeSpan.FromSeconds(result.Data.ExpiresIn));

            return Result.Success(result.Data!.AccessToken);
        }
        else
        {
            return Result.Success(accessToken);
        }
    }

    public async Task<Result<SubmitReceiptsResponse>> Submit(SubmitReceiptsRequest documents,AuthPOSRequest request)
    {

        var accessToken = await _cacheService.GetAsync<string>(request.ClientId);

        if(accessToken is null)
        {
            var result = await _etaManager.EtaAuthService.AuthenticatePOSAsync(request);
            if (!result.IsSuccess)
                return Result.Failure<SubmitReceiptsResponse>(new Error("", JsonConvert.SerializeObject(result.Error), result.StatusCode));

            await _cacheService.SetAsync<string>(request.ClientId, result.Data.AccessToken, TimeSpan.FromSeconds(result.Data.ExpiresIn));
            accessToken = result.Data.AccessToken;
        }

        var submitResult = await _etaManager.ReceiptService.SubmitReceiptsAsync(accessToken, documents);
          
        if (!submitResult.IsSuccess)
            return Result.Failure<SubmitReceiptsResponse>(new Error(submitResult.StatusCode.ToString(),submitResult.Error.Error ,submitResult.StatusCode));

        return Result.Success(submitResult.Data);
    }
}

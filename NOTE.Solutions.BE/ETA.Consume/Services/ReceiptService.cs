using System.Net;
using System.Net.Http.Json;

namespace ETA.Consume.Services;

public class ReceiptService : IReceiptService
{
    private readonly IUUIDService _uuidService;
    private readonly BaseApiCallService _apiCall;
    public ReceiptService(BaseApiCallService apiCall,IUUIDService uuidService)
    {
        _uuidService = uuidService;
        _apiCall = apiCall;
    }
    public async Task<ApiResult<SubmitReceiptsResponse>> SubmitReceiptsAsync(string accessToken, SubmitReceiptsRequest Documents)
    {
        foreach(var document in Documents.Receipts)
        {
            document.Header.UUID = _uuidService.GenerateUUID(document);
        }

        var headers = new Dictionary<string, string>()
        {
            { "Authorization" , $"Bearer {accessToken}" },
            { "Accept-Language" , "ar"   }
        };

        return await _apiCall.PostReturnAsync<SubmitReceiptsRequest,SubmitReceiptsResponse>("api/v1/receiptsubmissions", Documents, headers);
    }
}

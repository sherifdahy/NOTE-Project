using ETA.Consume.Contracts.Auth.Requests;
using ETA.Consume.Contracts.Receipt.Requests;
using ETA.Consume.Contracts.Receipt.Responses;
using NOTE.Solutions.Entities.Entities.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Interfaces;

public interface IETAService
{
    Task<Result<string>> GetTokenAsync(AuthPOSRequest request);
    Task<Result<SubmitReceiptsResponse>> Submit(SubmitReceiptsRequest documents, AuthPOSRequest request);

}

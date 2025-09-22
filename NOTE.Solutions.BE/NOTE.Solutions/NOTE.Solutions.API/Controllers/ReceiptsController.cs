using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NOTE.Solutions.BLL.Contracts.Document.Requests;

namespace NOTE.Solutions.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ReceiptsController(IReceiptService receiptService) : ControllerBase
{
    private readonly IReceiptService _receiptService = receiptService;

    [HttpGet("~/branches/{branchId:int}/receipts")]
    public async Task<IActionResult> GetAll(int branchId,CancellationToken cancellationToken)
    {
        var result = await _receiptService.GetAllAsync(branchId,cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id,CancellationToken cancellationToken)
    {
        var result = await _receiptService.GetByIdAsync(id,cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost("~/branches/{branchId:int}/pos/{posId}/receipts")]
    public async Task<IActionResult> Create(int branchId,int activeCodeId,int posId,DocumentRequest request,CancellationToken cancellationToken)
    {
        var result = await _receiptService.CreateAsync(branchId,activeCodeId,posId,request, cancellationToken);

        return result.IsSuccess ? Created() : result.ToProblem();
    }
}

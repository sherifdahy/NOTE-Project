using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NOTE.Solutions.BLL.Contracts.POS.Requests;

namespace NOTE.Solutions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POSsController(IPOSService pOSService) : ControllerBase
    {
        private readonly IPOSService _pOSService = pOSService;

        [HttpGet("~/branches/{branchId:int}/POSs")]
        public async Task<IActionResult> GetAll(int branchId,CancellationToken cancellationToken)
        {
            var result = await _pOSService.GetAllAsync(branchId, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }


        [HttpPost]
        public async Task<IActionResult> Create(int branchId, POSRequest request,CancellationToken cancellationToken)
        {
            var result = await _pOSService.CreateAsync(branchId, request, cancellationToken);
            return result.IsSuccess ? Created() : result.ToProblem();
        }
    }
}

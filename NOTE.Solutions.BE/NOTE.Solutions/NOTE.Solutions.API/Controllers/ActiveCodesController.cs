using Microsoft.AspNetCore.Authorization;

namespace NOTE.Solutions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ActiveCodesController(IActiveCodeService activeCodeService) : BaseController
    {
        private readonly IActiveCodeService activeCodeService = activeCodeService;

        [HttpGet]
        public async Task<IActionResult> GetAll(int companyId)
        {
            var result = await activeCodeService.GetAllAsync(companyId);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await activeCodeService.GetById(id);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int companyId,ActiveCodeRequest request)
        {
            var result = await activeCodeService.CreateAsync(companyId, request);
            return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value) : result.ToProblem();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActiveCodeRequest request)
        {
            var result = await activeCodeService.UpdateAsync(id, request);
            return result.IsSuccess ? NoContent() : result.ToProblem();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await activeCodeService.DeleteAsync(id);
            return result.IsSuccess ? NoContent() : result.ToProblem();
        }
    }
}

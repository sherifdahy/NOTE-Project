using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NOTE.Solutions.BLL.Contracts.DocumentType.Requests;

namespace NOTE.Solutions.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DocumentTypesController(IDocumentTypeService documentTypeService) : ControllerBase
{
    private readonly IDocumentTypeService _documentTypeService = documentTypeService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _documentTypeService.GetAllAsync();
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{documentTypeId:int}")]
    public async Task<IActionResult> GetById(int documentTypeId)
    {
        var result = await _documentTypeService.GetByIdAsync(documentTypeId);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DocumentTypeRequest request)
    {
        var result = await _documentTypeService.CreateAsync(request);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { documentTypeId = result.Value.Id }, result.Value) : result.ToProblem();
    }

    [HttpPut("{documentTypeId:int}")]
    public async Task<IActionResult> Update(int documentTypeId, [FromBody] DocumentTypeRequest request)
    {
        var result = await _documentTypeService.UpdateAsync(documentTypeId, request);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpDelete("{documentTypeId:int}")]
    public async Task<IActionResult> Delete(int documentTypeId)
    {
        var result = await _documentTypeService.DeleteAsync(documentTypeId);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}

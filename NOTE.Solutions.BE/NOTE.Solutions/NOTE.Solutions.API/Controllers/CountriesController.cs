using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NOTE.Solutions.BLL.Contracts.Country.Requests;

namespace NOTE.Solutions.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CountriesController(ICountryService countryService) : ControllerBase
{
    private readonly ICountryService _countryService = countryService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _countryService.GetAllAsync();
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{countryId:int}")]
    public async Task<IActionResult> GetById(int countryId)
    {
        var result = await _countryService.GetByIdAsync(countryId);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CountryRequest request)
    {
        var result = await _countryService.CreateAsync(request);
        return result.IsSuccess ? CreatedAtAction(nameof(GetById), new { countryId = result.Value.Id }, result.Value) : result.ToProblem();
    }

    [HttpPut("{countryId:int}")]
    public async Task<IActionResult> Update(int countryId, [FromBody] CountryRequest request)
    {
        var result = await _countryService.UpdateAsync(countryId, request);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpDelete("{countryId:int}")]
    public async Task<IActionResult> Delete(int countryId)
    {
        var result = await _countryService.DeleteAsync(countryId);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

}

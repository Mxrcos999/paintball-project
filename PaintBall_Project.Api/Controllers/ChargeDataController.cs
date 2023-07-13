using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Update;
using Paintball_Project.Application.Interfaces.Services;

namespace PaintBall_Project.Api.Controllers;

[Authorize]
[Route("chargeData")]
[ApiController]
public class ChargeDataController : Controller
{
    private readonly IChargeDataService _chargeDataService;

    public ChargeDataController(IChargeDataService chargeDataService)
    {
        _chargeDataService = chargeDataService;
    }

    [HttpPost]
    public async Task<ActionResult> InsertAsync([FromBody] ChargeDataInsertRequest model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _chargeDataService.CreateAsync(model);

        if (!result)
            return BadRequest(result);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        var result = await _chargeDataService.GetAsync();

        return Ok(result);
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateAsync([FromBody] ChargeDataUpdateRequest model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _chargeDataService.UpdateAsync(model);
        
        if (!result)
            return BadRequest(result);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var result = await _chargeDataService.DeleteAsync(id);
        
        if (!result)
            return BadRequest(result);

        return Ok();
    }
}

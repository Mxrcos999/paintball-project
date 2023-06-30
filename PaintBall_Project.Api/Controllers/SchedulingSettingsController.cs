using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.Interfaces.Services;

namespace PaintBall_Project.Api.Controllers;
[ApiController]
[Route("Scheduling_Settings")]
public class SchedulingSettingsController : Controller
{
    private readonly ISchedulingSettingsService _schedulingService;

    public SchedulingSettingsController(ISchedulingSettingsService schedulingService)
    {
        _schedulingService = schedulingService;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        var result = await _schedulingService.GetAsync();

        if(result is null)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut] 
    public async Task<ActionResult> UpdateAsync([FromBody] SchedulingSettingsRequest model)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _schedulingService.UpdateAsync(model);

        if (result is null)
            return BadRequest(result);

        return Ok(result);
    } 
}

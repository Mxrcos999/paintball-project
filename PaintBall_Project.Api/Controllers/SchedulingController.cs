using Microsoft.AspNetCore.Mvc;
using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Update;
using Paintball_Project.Application.Interfaces.Services;
using System.Diagnostics;

namespace PaintBall_Project.Api.Controllers;

[ApiController]
[Route("/Scheduling")]
public class SchedulingController : ControllerBase
{
    private readonly ISchedulingService _schedulingService;

    public SchedulingController(ISchedulingService schedulingService)
    {
        _schedulingService = schedulingService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync([FromBody] SchedulingInsertRequest request)
    {
        if(!ModelState.IsValid) 
            return BadRequest(ModelState);

        var result = await _schedulingService.InsertAsync(request);

        if (!result.Sucess)
            return BadRequest(result);

        return Ok(result);  
    }
    [HttpGet]
    public async Task<ActionResult> GetDaysAvailableAsync(int mounth, int day)
    {
        var result = await _schedulingService.GetAsync(mounth, day);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] SchedulingUpdateRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(request);

        var result = await _schedulingService.UpdateAsync(request);

        if(!result)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        if (id < 1)
            return BadRequest(id);

        var result = await _schedulingService.DeleteAsync(id);

        if(!result)
            return BadRequest(result);

        return Ok(result);
    }
}

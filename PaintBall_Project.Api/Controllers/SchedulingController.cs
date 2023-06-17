using Microsoft.AspNetCore.Mvc;
using Paintball_Project.Application.DTOs.Insert;
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

        if (result == 0)
            return BadRequest(result);

        return Ok(result);  
    }
    [HttpGet]
    public async Task<ActionResult> GetDaysAvailableAsync()
    {
        var sw = new Stopwatch();
        sw.Start();
        var result = await _schedulingService.GetAsync();
        sw.Stop();
        var time = sw.Elapsed;

        return Ok(result);

    }
}

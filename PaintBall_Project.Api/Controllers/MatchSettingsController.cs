using Microsoft.AspNetCore.Mvc;
using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Update;
using Paintball_Project.Application.Interfaces.Services;

namespace PaintBall_Project.Api.Controllers;

[ApiController]
[Route("/match_settings")]
public class MatchSettingsController : ControllerBase
{
    private readonly IMatchService _matchService;

    public MatchSettingsController(IMatchService matchService)
    {
        _matchService = matchService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        return Ok(await _matchService.GetAsync());
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] MatchUpdateRequest model)
    {
        if (!ModelState.IsValid) { return BadRequest(model); }

        var result = await _matchService.UpdateAsync(model);


        if (result)
            return Ok();

        return BadRequest();
    }
}

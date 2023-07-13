using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Update;
using Paintball_Project.Application.Interfaces.Services;

namespace PaintBall_Project.Api.Controllers;
[ApiController]
[Route("GameData")]
[Authorize]
public class GameDataController : Controller
{
    private readonly IGameDataService _gameDataService;

    public GameDataController(IGameDataService gameDataService)
    {
        _gameDataService = gameDataService;
    }

    [HttpPost]
    public async Task<ActionResult> InsertAsync([FromBody] GameDataInsertRequest model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _gameDataService.CreateAsync(model);

        if (!result)
            return BadRequest(result);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        var result = await _gameDataService.GetAsync();

        return Ok(result);
    }

    [HttpPatch]
    public async Task<ActionResult> UpdateAsync([FromBody] GameDataUpdateRequest model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _gameDataService.UpdateAsync(model);

        if (!result)
            return BadRequest(result);

        return Ok();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var result = await _gameDataService.DeleteAsync(id);

        if (!result)
            return BadRequest(result);

        return Ok();
    }
}

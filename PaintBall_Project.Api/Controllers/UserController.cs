using Microsoft.AspNetCore.Mvc;
using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.Interfaces.Services;
using Paintball_Project.Storage.Services;

namespace PaintBall_Project.Api.Controllers;
[ApiController]
public class UserController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public UserController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost]
    [Route("user/login")]
    public async Task<ActionResult> LoginAsync([FromBody] LoginRequest model)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _identityService.LoginAsync(model);

        if(result.Success)
            return Ok(result);

        return BadRequest(result);
    }  
    
    [HttpPost]
    [Route("user/logout")]

    public async Task<ActionResult> LogoutAsync()
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        return(Ok());
    }    

    [HttpPost]
    [Route("user/register")]
    public async Task<ActionResult> UserRegisterAsync([FromBody] UserRegisterRequest userRegisterRequest)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _identityService.RegisterUser(userRegisterRequest);

        if(result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    //[HttpPost]
    //[Route("upload_storage")]
    //public async Task Storage()
    //{
    //    await blob.UploadImageAsync();
    //}  

    //[HttpPost]
    //[Route("download_storage")]
    //public async Task<ActionResult> StorageDownload()
    //{
    //    var downloadResponse = await blob.DownloadImageAsync("C:\\Users\\marco");

    //    return File(downloadResponse.Value.Content, downloadResponse.Value.ContentType, "imagem.jpg");

    //}


}

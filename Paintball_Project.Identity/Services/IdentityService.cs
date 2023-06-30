namespace Paintball_Project.Identity.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Paintball_Project.Application.DTOs.Insert;
using Paintball_Project.Application.DTOs.Response;
using Paintball_Project.Application.Interfaces.Services;
using Paintball_Project.Domain.Entities;
using Paintball_Project.Identity.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


public class IdentityService : IIdentityService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtOptions _jwtOptions;

    public IdentityService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IOptions<JwtOptions> jwtOptions)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtOptions = jwtOptions.Value;

    }

    public async Task<UserLoginResponse> LoginAsync(LoginRequest userLogin)
    {
        SignInResult signInResult = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, isPersistent: false, lockoutOnFailure: true);
        if (signInResult.Succeeded)
        {
            var credenciais = await GerarCredenciais(userLogin.Email);
            return credenciais;
        }

        UserLoginResponse userLoginResponse = new UserLoginResponse(signInResult.Succeeded);
        if (!signInResult.Succeeded)
        {
            if (signInResult.IsLockedOut)
            {
                userLoginResponse.AddError("Esta conta está bloqueada.");
            }
            else if (signInResult.IsNotAllowed)
            {
                userLoginResponse.AddError("Esta conta não tem permissão para entrar.");
            }
            else if (signInResult.RequiresTwoFactor)
            {
                userLoginResponse.AddError("Confirme seu email.");
            }
            else
            {
                userLoginResponse.AddError("Nome de usuário ou senha estão incorretos.");
            }
        }

        return userLoginResponse;
    }
    public async Task<UserRegisterResponse> RegisterUser(UserRegisterRequest userRegister)
    {
        var user = new ApplicationUser()
        {
            Email = userRegister.Email,
            UserName = userRegister.Email,

        };
        IdentityResult result = await _userManager.CreateAsync(user, userRegister.Password);

        UserRegisterResponse userRegisterResponse = new UserRegisterResponse(result.Succeeded);

        if (!result.Succeeded)
        {
            foreach (var erroAtual in result.Errors)
            {
                switch (erroAtual.Code)
                {
                    case "PasswordRequiresNonAlphanumeric":
                        userRegisterResponse.AddError("A senha precisa conter pelo menos um caracter especial - ex( * | ! ).");
                        break;

                    case "PasswordRequiresDigit":
                        userRegisterResponse.AddError("A senha precisa conter pelo menos um número (0 - 9).");
                        break;

                    case "PasswordRequiresUpper":
                        userRegisterResponse.AddError("A senha precisa conter pelo menos um caracter em maiúsculo.");
                        break;

                    case "DuplicateUserName":
                        userRegisterResponse.AddError("O email informado já foi cadastrado!");
                        break;

                    default:
                        userRegisterResponse.AddError("Erro ao criar usuário.");
                        break;
                }

            }
        }

        return userRegisterResponse;
    }
    private async Task<UserLoginResponse> GerarCredenciais(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var accessTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: true);
        var refreshTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: false);

        var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
        var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

        var accessToken = GerarToken(accessTokenClaims, dataExpiracaoAccessToken);
        var refreshToken = GerarToken(refreshTokenClaims, dataExpiracaoRefreshToken);

        return new UserLoginResponse
        (
            success: true,
            accessToken: accessToken,
            refreshToken: refreshToken
        );
    }
    private string GerarToken(IEnumerable<Claim> claims, DateTime dataExpiracao)
    {
        JwtSecurityToken token = new JwtSecurityToken(_jwtOptions.Issuer, _jwtOptions.Audience, claims, DateTime.Now, dataExpiracao, _jwtOptions.SigningCredentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    private async Task<IList<Claim>> ObterClaims(ApplicationUser user, bool adicionarClaimsUsuario)
    {
        var claims = new List<Claim>();

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

        if (adicionarClaimsUsuario)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(userClaims);

            foreach (var role in roles)
                claims.Add(new Claim("role", role));
        }

        return claims;
    }

}

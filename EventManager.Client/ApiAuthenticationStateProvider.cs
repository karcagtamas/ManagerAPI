using EventManager.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace EventManager.Client;

/// <summary>
/// Auth state manager
/// </summary>
public class ApiAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ITokenService tokenService;

    /// <summary>
    /// Init Auth State
    /// </summary>
    /// <param name="tokenService"></param>
    public ApiAuthenticationStateProvider(ITokenService tokenService)
    {
        this.tokenService = tokenService;
    }

    /// <summary>
    /// Mark user as authenticated
    /// </summary>
    public void MarkUserAsAuthenticated()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    /// <summary>
    /// Get state
    /// </summary>
    /// <returns></returns>
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        await tokenService.RefreshStore();
        var token = await tokenService.GetUser();

        if (token is null || string.IsNullOrEmpty(token.AccessToken))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var accessToken = token.AccessToken;

        return new AuthenticationState(
            new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(accessToken), "jwt")));
    }

    /// <summary>
    /// Mark user as logged out
    /// </summary>
    public void MarkUserAsLoggedOut()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonymousUser));
        NotifyAuthenticationStateChanged(authState);
    }
    
    private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var jwtToken = new JwtSecurityToken(jwt);

        return jwtToken.Claims;
    }
}

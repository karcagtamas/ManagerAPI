using ManagerAPI.Domain.Entities;
using ManagerAPI.Shared.DTOs;

namespace ManagerAPI.Services.Services.Interfaces;

/// <summary>
/// Token Service
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Build Access Token
    /// </summary>
    /// <param name="user">Source user</param>
    /// <param name="roles">Roles</param>
    /// <returns>New token</returns>
    string BuildAccessToken(UserTokenDTO user, IList<string> roles);

    /// <summary>
    /// Build Refresh Token
    /// </summary>
    /// <param name="clientId">Client Id</param>
    /// <returns>Refresh token</returns>
    RefreshToken BuildRefreshToken(string clientId);

    /// <summary>
    /// Refresh Auth
    /// </summary>
    /// <param name="refreshToken">Refresh token</param>
    /// <param name="clientId">Client Id</param>
    /// <returns>Token</returns>
    Task<TokenDTO> Refresh(string refreshToken, string clientId);
}

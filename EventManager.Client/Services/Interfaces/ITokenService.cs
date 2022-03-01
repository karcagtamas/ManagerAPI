using ManagerAPI.Shared.DTOs;

namespace EventManager.Client.Services.Interfaces;

/// <summary>
/// Token Service
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Get User
    /// </summary>
    Task<TokenDTO?> GetUser();

    /// <summary>
    /// Refresh Store
    /// </summary>
    Task RefreshStore();

    /// <summary>
    /// Set new user
    /// </summary>
    /// <param name="dto">New object</param>
    Task SetUser(TokenDTO dto);

    /// <summary>
    /// Clear user data
    /// </summary>
    Task ClearUser();

    /// <summary>
    /// Check user is in the store
    /// </summary>
    bool UserInStore();
}

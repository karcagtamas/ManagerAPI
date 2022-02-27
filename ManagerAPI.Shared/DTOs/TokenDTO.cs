namespace ManagerAPI.Shared.DTOs;

/// <summary>
/// Token DTO
/// </summary>
public class TokenDTO
{
    /// <summary>
    /// Access Token
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// Refresh Token
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;

    /// <summary>
    /// Client Id
    /// </summary>
    public string ClientId { get; set; } = string.Empty;

    /// <summary>
    /// User Id
    /// </summary>
    public string UserId { get; set; } = string.Empty;
}

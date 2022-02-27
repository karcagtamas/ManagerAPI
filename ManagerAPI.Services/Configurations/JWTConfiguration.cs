namespace ManagerAPI.Services.Configurations;

/// <summary>
/// JWT
/// </summary>
public class JWTConfiguration
{
    /// <summary>
    /// Key
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// Issuer
    /// </summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>
    /// Expiration in minutes
    /// </summary>
    public int ExpirationInMinutes { get; set; } = 60;
}

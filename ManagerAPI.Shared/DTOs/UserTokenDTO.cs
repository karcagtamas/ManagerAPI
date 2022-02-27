namespace ManagerAPI.Shared.DTOs;

/// <summary>
/// User token DTO
/// </summary>
public class UserTokenDTO
{
    /// <summary>
    /// Id
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// User Name
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// E-mail
    /// </summary>
    public string Email { get; set; } = string.Empty;
}

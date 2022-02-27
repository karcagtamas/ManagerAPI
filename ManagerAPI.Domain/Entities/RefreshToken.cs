using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities;

/// <summary>
/// Refresh Token
/// </summary>
public class RefreshToken
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Token
    /// </summary>
    [Required]
    public string Token { get; set; } = "";

    /// <summary>
    /// Expiration date
    /// </summary>
    [Required]
    public DateTime Expires { get; set; }

    /// <summary>
    /// Creation
    /// </summary>
    [Required]
    public DateTime Created { get; set; }

    /// <summary>
    /// Revoke
    /// </summary>
    public DateTime? Revoked { get; set; }

    /// <summary>
    /// User Id
    /// </summary>
    [Required]
    public string UserId { get; set; } = "";

    /// <summary>
    /// Client Id
    /// </summary>
    public string ClientId { get; set; } = "";

    /// <summary>
    /// User
    /// </summary>
    public virtual User? User { get; set; }

    /// <summary>
    /// Is expired
    /// </summary>
    public bool IsExpired => DateTime.UtcNow >= Expires;

    /// <summary>
    /// Is active
    /// </summary>
    public bool IsActive => Revoked == null && !IsExpired;
}

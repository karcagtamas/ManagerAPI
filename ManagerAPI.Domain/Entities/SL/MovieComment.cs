using KarcagS.Common.Tools.Entities;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL;

/// <summary>
/// Movie comment
/// </summary>
public class MovieComment : IEntity<int>
{
    /// <inheritdoc />
    public int Id { get; set; }

    /// <summary>
    /// Movie
    /// </summary>
    [Required] public int MovieId { get; set; }

    /// <summary>
    /// User
    /// </summary>
    [Required] public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// Creation
    /// </summary>
    [Required] public DateTime Creation { get; set; }

    /// <summary>
    /// Last update
    /// </summary>
    [Required] public DateTime LastUpdate { get; set; }

    /// <summary>
    /// Comment
    /// </summary>
    [Required] [MaxLength(500)] public string Comment { get; set; } = string.Empty;

    /// <summary>
    /// Movie
    /// </summary>
    public virtual Movie Movie { get; set; } = default!;

    /// <summary>
    /// User
    /// </summary>
    public virtual User User { get; set; } = default!;
}

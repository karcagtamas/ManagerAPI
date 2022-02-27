using KarcagS.Common.Tools.Entities;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL;

/// <summary>
/// Book
/// </summary>
public class Book : IEntity<int>
{
    /// <inheritdoc />
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Author
    /// </summary>
    [Required]
    [MaxLength(150)]
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Publish
    /// </summary>
    public DateTime? Publish { get; set; }

    /// <summary>
    /// Creator
    /// </summary>
    [Required]
    public string CreatorId { get; set; } = string.Empty;

    /// <summary>
    /// Last updater
    /// </summary>
    [Required]
    public string LastUpdaterId { get; set; } = string.Empty;

    /// <summary>
    /// Creation
    /// </summary>
    [Required]
    public DateTime Creation { get; set; }

    /// <summary>
    /// Last update
    /// </summary>
    [Required]
    public DateTime LastUpdate { get; set; }

    /// <summary>
    /// Creator
    /// </summary>
    [Required]
    public virtual User Creator { get; set; } = default!;

    /// <summary>
    /// Last updater
    /// </summary>
    [Required]
    public virtual User LastUpdater { get; set; } = default!;

    /// <summary>
    /// Users
    /// </summary>
    public virtual ICollection<UserBook> ConnectedUsers { get; set; } = default!;

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj != null && this.Id == ((Book)obj).Id;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(this.Id);
        hash.Add(this.Name);
        hash.Add(this.Author);
        hash.Add(this.Description);
        hash.Add(this.Publish);
        hash.Add(this.CreatorId);
        hash.Add(this.LastUpdaterId);
        hash.Add(this.Creation);
        hash.Add(this.LastUpdate);
        hash.Add(this.Creator);
        hash.Add(this.LastUpdater);
        hash.Add(this.ConnectedUsers);
        return hash.ToHashCode();
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{this.Id} - {this.Name}";
    }
}

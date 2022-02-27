using KarcagS.Common.Tools.Entities;
using ManagerAPI.Shared.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL;

/// <summary>
/// Series
/// </summary>
public class Series : IEntity<int>
{
    /// <inheritdoc />
    [Required] public int Id { get; set; }

    /// <summary>
    /// Title
    /// </summary>
    [Required] [MaxLength(150)] public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Description
    /// </summary>
    [MaxLength(999)] public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Start year
    /// </summary>
    [MinNumber(1900)] public int? StartYear { get; set; }

    /// <summary>
    /// End year
    /// </summary>
    [MinNumber(1900)] public int? EndYear { get; set; }

    /// <summary>
    /// Trailer url
    /// </summary>
    [MaxLength(200)] public string TrailerUrl { get; set; } = string.Empty;

    /// <summary>
    /// Image title
    /// </summary>
    [MaxLength(100)] public string ImageTitle { get; set; } = string.Empty;

    /// <summary>
    /// Image
    /// </summary>
    public byte[] ImageData { get; set; } = default!;

    /// <summary>
    /// Creation
    /// </summary>
    [Required] public DateTime Creation { get; set; }

    /// <summary>
    /// Last update
    /// </summary>
    [Required] public DateTime LastUpdate { get; set; }

    /// <summary>
    /// Creator
    /// </summary>
    [Required] public string CreatorId { get; set; } = string.Empty;

    /// <summary>
    /// Last updater
    /// </summary>
    [Required] public string LastUpdaterId { get; set; } = string.Empty;

    /// <summary>
    /// Seasons
    /// </summary>
    public virtual ICollection<Season> Seasons { get; set; } = default!;

    /// <summary>
    /// Creator
    /// </summary>
    public virtual User Creator { get; set; } = default!;

    /// <summary>
    /// Last updater
    /// </summary>
    public virtual User LastUpdater { get; set; } = default!;

    /// <summary>
    /// Users
    /// </summary>
    public virtual ICollection<UserSeries> ConnectedUsers { get; set; } = default!;

    /// <summary>
    /// Categories
    /// </summary>
    public virtual ICollection<SeriesSeriesCategory> Categories { get; set; } = default!;

    /// <summary>
    /// Comments
    /// </summary>
    public virtual ICollection<SeriesComment> Comments { get; set; } = default!;

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj != null && this.Id == ((Series)obj).Id;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(this.Id);
        hash.Add(this.Title);
        hash.Add(this.Description);
        hash.Add(this.TrailerUrl);
        hash.Add(this.ImageTitle);
        hash.Add(this.ImageData);
        hash.Add(this.StartYear);
        hash.Add(this.EndYear);
        hash.Add(this.Creation);
        hash.Add(this.LastUpdate);
        hash.Add(this.CreatorId);
        hash.Add(this.LastUpdaterId);
        return hash.ToHashCode();
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return EntityStringBuilder.BuildString(this, "Id", "Title");
    }
}

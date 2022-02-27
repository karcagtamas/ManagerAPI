using KarcagS.Common.Tools.Entities;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL;

/// <summary>
/// Series category
/// </summary>
public class SeriesCategory : IEntity<int>
{
    /// <inheritdoc />
    [Required] public int Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [Required] [MaxLength(120)] public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Connected Serieses
    /// </summary>
    public virtual ICollection<SeriesSeriesCategory> ConnectedSeriesList { get; set; } = default!;

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj != null && this.Id == ((Movie)obj).Id;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(this.Id);
        hash.Add(this.Name);
        return hash.ToHashCode();
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return EntityStringBuilder.BuildString(this, "Id", "Name");
    }
}

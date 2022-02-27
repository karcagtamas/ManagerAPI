﻿using KarcagS.Common.Tools.Entities;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL;

/// <summary>
/// Season
/// </summary>
public class Season : IEntity<int>
{
    /// <inheritdoc />
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// Number
    /// </summary>
    [Required]
    public int Number { get; set; }

    /// <summary>
    /// Series
    /// </summary>
    [Required]
    public int SeriesId { get; set; }

    /// <summary>
    /// Series
    /// </summary>
    public virtual Series Series { get; set; } = default!;

    /// <summary>
    /// Episodes
    /// </summary>
    public virtual ICollection<Episode> Episodes { get; set; } = default!;

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj != null && this.Id == ((Season)obj).Id;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Id, this.Number, this.SeriesId, this.Series, this.Episodes);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{this.Id} - {this.Number}";
    }
}

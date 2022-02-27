﻿using KarcagS.Common.Tools.Entities;
using ManagerAPI.Shared.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL;

/// <summary>
/// Episode
/// </summary>
public class Episode : IEntity<int>
{
    /// <inheritdoc />
    [Required] public int Id { get; set; }

    /// <summary>
    /// Title
    /// </summary>
    [Required] [MaxLength(150)] public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Number
    /// </summary>
    [Required]
    [MinNumber(1)]
    [MaxNumber(99)]
    public int Number { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    [MaxLength(300)] public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Season
    /// </summary>
    [Required] public int SeasonId { get; set; }

    /// <summary>
    /// Last updater
    /// </summary>
    [Required] public string LastUpdaterId { get; set; } = string.Empty;

    /// <summary>
    /// Last update
    /// </summary>
    [Required] public DateTime LastUpdate { get; set; }

    /// <summary>
    /// Image title
    /// </summary>
    public string ImageTitle { get; set; } = string.Empty;

    /// <summary>
    /// Image
    /// </summary>
    public byte[] ImageData { get; set; } = default!;

    /// <summary>
    /// Season
    /// </summary>
    public virtual Season Season { get; set; } = default!;

    /// <summary>
    /// Last updater
    /// </summary>
    public virtual User LastUpdater { get; set; } = default!;

    /// <summary>
    /// Users
    /// </summary>
    public virtual ICollection<UserEpisode> ConnectedUsers { get; set; } = default!;

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj != null && ((Episode)obj).Id == this.Id;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(this.Id);
        hash.Add(this.Title);
        hash.Add(this.Description);
        hash.Add(this.ImageTitle);
        hash.Add(this.ImageData);
        hash.Add(this.LastUpdate);
        hash.Add(this.Number);
        hash.Add(this.LastUpdaterId);
        return hash.ToHashCode();
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{this.Id} - {this.Number}";
    }
}

﻿using ManagerAPI.Shared.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities.SL
{
    /// <summary>
    /// Movie
    /// </summary>
    public class Movie : IEntity
    {
        /// <inheritdoc />
        [Required] public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required] [MaxLength(150)] public string Title { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [MaxLength(999)] public string Description { get; set; }

        /// <summary>
        /// Release year
        /// </summary>
        [MinNumber(1900)] public int? ReleaseYear { get; set; }

        /// <summary>
        /// Length
        /// </summary>
        [MaxNumber(999)] [MinNumber(1)] public int? Length { get; set; }

        /// <summary>
        /// Director
        /// </summary>
        [MaxLength(60)] public string Director { get; set; }

        /// <summary>
        /// Trailer url
        /// </summary>
        [MaxLength(200)] public string TrailerUrl { get; set; }

        /// <summary>
        /// Image title
        /// </summary>
        [MaxLength(100)] public string ImageTitle { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        public byte[] ImageData { get; set; }

        /// <summary>
        /// Creator
        /// </summary>
        [Required] public string CreatorId { get; set; }

        /// <summary>
        /// Last updater
        /// </summary>
        [Required] public string LastUpdaterId { get; set; }

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
        public virtual User Creator { get; set; }

        /// <summary>
        /// Last updater
        /// </summary>
        public virtual User LastUpdater { get; set; }

        /// <summary>
        /// Users
        /// </summary>
        public virtual ICollection<UserMovie> ConnectedUsers { get; set; }

        /// <summary>
        /// Categories
        /// </summary>
        public virtual ICollection<MovieMovieCategory> Categories { get; set; }

        /// <summary>
        /// Comments
        /// </summary>
        public virtual ICollection<MovieComment> Comments { get; set; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj != null && this.Id == ((Movie)obj).Id;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(this.Id);
            hash.Add(this.Title);
            hash.Add(this.Description);
            hash.Add(this.ReleaseYear);
            hash.Add(this.Length);
            hash.Add(this.Director);
            hash.Add(this.TrailerUrl);
            hash.Add(this.ImageTitle);
            hash.Add(this.ImageData);
            hash.Add(this.CreatorId);
            hash.Add(this.LastUpdaterId);
            hash.Add(this.Creation);
            hash.Add(this.LastUpdate);
            return hash.ToHashCode();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return EntityStringBuilder.BuildString(this, "Id", "Title", "ReleaseYear");
        }
    }
}
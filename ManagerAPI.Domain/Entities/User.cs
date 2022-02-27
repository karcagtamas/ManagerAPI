using KarcagS.Common.Tools.Entities;
using ManagerAPI.Domain.Entities.CSM;
using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Domain.Entities.WM;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.Domain.Entities;

/// <summary>
/// User
/// </summary>
public class User : IdentityUser, IEntity<string>
{
    /// <summary>
    /// Full name
    /// </summary>
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Is active
    /// </summary>
    [Required]
    public bool IsActive { get; set; }

    /// <summary>
    /// Registration date
    /// </summary>
    [Required]
    public DateTime RegistrationDate { get; set; }

    /// <summary>
    /// Last login
    /// </summary>
    [Required]
    public DateTime LastLogin { get; set; }

    /// <summary>
    /// Secondary email
    /// </summary>
    [EmailAddress]
    public string SecondaryEmail { get; set; } = string.Empty;

    /// <summary>
    /// TShirt size
    /// </summary>
    [MaxLength(6)]
    public string TShirtSize { get; set; } = string.Empty;

    /// <summary>
    /// Allergy
    /// </summary>
    public string Allergy { get; set; } = string.Empty;

    /// <summary>
    /// Group
    /// </summary>
    [MaxLength(40)]
    public string Group { get; set; } = string.Empty;

    /// <summary>
    /// Birthday
    /// </summary>
    public DateTime? BirthDay { get; set; }

    /// <summary>
    /// Profile image title
    /// </summary>
    public string? ProfileImageTitle { get; set; } = string.Empty;

    /// <summary>
    /// Profile image
    /// </summary>
    public byte[]? ProfileImageData { get; set; } = default!;

    /// <summary>
    /// Country
    /// </summary>
    [MaxLength(120)]
    public string Country { get; set; } = string.Empty;

    /// <summary>
    /// Gender
    /// </summary>
    public int? GenderId { get; set; }

    /// <summary>
    /// City
    /// </summary>
    [MaxLength(120)]
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gender
    /// </summary>
    public virtual Gender? Gender { get; set; } = default!;

    /// <summary>
    /// Refresh tokens
    /// </summary>
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    /// <summary>
    /// Notifications
    /// </summary>
    public virtual ICollection<Notification> Notifications { get; set; } = default!;

    /// <summary>
    /// Send friend requests
    /// </summary>
    public virtual ICollection<FriendRequest> SentFriendRequest { get; set; } = default!;

    /// <summary>
    /// Received friend requests
    /// </summary>
    public virtual ICollection<FriendRequest> ReceivedFriendRequest { get; set; } = default!;

    /// <summary>
    /// Friend list
    /// </summary>
    public virtual ICollection<Friends> FriendListLeft { get; set; } = default!;

    /// <summary>
    /// Friend list
    /// </summary>
    public virtual ICollection<Friends> FriendListRight { get; set; } = default!;

    /// <summary>
    /// Sent messages
    /// </summary>
    public virtual ICollection<Message> SentMessages { get; set; } = default!;

    /// <summary>
    /// Received messages
    /// </summary>
    public virtual ICollection<Message> ReceivedMessages { get; set; } = default!;

    /// <summary>
    /// Created news
    /// </summary>
    public virtual ICollection<News> CreatedNews { get; set; } = default!;

    /// <summary>
    /// Updated news
    /// </summary>
    public virtual ICollection<News> UpdatedNews { get; set; } = default!;

    /// <summary>
    /// Tasks
    /// </summary>
    public virtual ICollection<Task> Tasks { get; set; } = default!;

    /// <summary>
    /// Working days
    /// </summary>
    public virtual ICollection<WorkingDay> WorkingDays { get; set; } = default!;

    /// <summary>
    /// Create movies
    /// </summary>
    public virtual ICollection<Movie> CreatedMovies { get; set; } = default!;

    /// <summary>
    /// Last updated movies
    /// </summary>
    public virtual ICollection<Movie> LastUpdatedMovies { get; set; } = default!;

    /// <summary>
    /// My movies
    /// </summary>
    public virtual ICollection<UserMovie> MyMovies { get; set; } = default!;


    /// <summary>
    /// Created serieses
    /// </summary>
    public virtual ICollection<Series> CreatedSeries { get; set; } = default!;


    /// <summary>
    /// Last updated serieses
    /// </summary>
    public virtual ICollection<Series> LastUpdatedSeries { get; set; } = default!;


    /// <summary>
    /// My series
    /// </summary>
    public virtual ICollection<UserSeries> MySeries { get; set; } = default!;


    /// <summary>
    /// My episodes
    /// </summary>
    public virtual ICollection<UserEpisode> MyEpisodes { get; set; } = default!;


    /// <summary>
    /// Created books
    /// </summary>
    public virtual ICollection<Book> CreatedBooks { get; set; } = default!;


    /// <summary>
    /// Last updated books
    /// </summary>
    public virtual ICollection<Book> LastUpdatedBooks { get; set; } = default!;


    /// <summary>
    /// My books
    /// </summary>
    public virtual ICollection<UserBook> MyBooks { get; set; } = default!;


    /// <summary>
    /// Created movies comments
    /// </summary>
    public virtual ICollection<MovieComment> MovieComments { get; set; } = default!;

    /// <summary>
    /// Created series comments
    /// </summary>
    public virtual ICollection<SeriesComment> SeriesComments { get; set; } = default!;

    /// <summary>
    /// Last updated episodes
    /// </summary>
    public virtual ICollection<Episode> LastUpdatedEpisodes { get; set; } = default!;

    /// <summary>
    /// Owned csomors
    /// </summary>
    public virtual ICollection<Csomor> OwnedCsomors { get; set; } = default!;

    /// <summary>
    /// Last updated csomors
    /// </summary>
    public virtual ICollection<Csomor> LastUpdatedCsomors { get; set; } = default!;

    /// <summary>
    /// Shared csomors
    /// </summary>
    public virtual ICollection<UserCsomor> SharedCsomors { get; set; } = default!;
}

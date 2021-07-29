using ManagerAPI.Domain.Entities.CSM;
using ManagerAPI.Domain.Entities.PM;
using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Domain.Entities.WM;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerAPI.Domain.Entities
{
    /// <summary>
    /// User
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Full name
        /// </summary>
        [MaxLength(100)]
        public string FullName { get; set; }

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
        public string SecondaryEmail { get; set; }

        /// <summary>
        /// TShirt size
        /// </summary>
        [MaxLength(6)]
        public string TShirtSize { get; set; }

        /// <summary>
        /// Allergy
        /// </summary>
        public string Allergy { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        [MaxLength(40)]
        public string Group { get; set; }

        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime? BirthDay { get; set; }

        /// <summary>
        /// Profile image title
        /// </summary>
        public string ProfileImageTitle { get; set; }

        /// <summary>
        /// Profile image
        /// </summary>
        public byte[] ProfileImageData { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [MaxLength(120)]
        public string Country { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public int? GenderId { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [MaxLength(120)]
        public string City { get; set; }

        /// <summary>
        /// Plans
        /// </summary>
        public virtual ICollection<Plan> Plans { get; set; }

        /// <summary>
        /// Created plan groups
        /// </summary>
        public virtual ICollection<PlanGroup> CreatedPlanGroups { get; set; }

        /// <summary>
        /// Last updated plan groups
        /// </summary>
        public virtual ICollection<PlanGroup> LastUpdatedPlanGroups { get; set; }

        /// <summary>
        /// Create plan group ideas
        /// </summary>
        public virtual ICollection<PlanGroupIdea> CreatedPlanGroupIdeas { get; set; }

        /// <summary>
        /// Sent plan group chat messages
        /// </summary>
        public virtual ICollection<PlanGroupChatMessage> SentPlanGroupChatMessages { get; set; }

        /// <summary>
        /// Marked plan group plan
        /// </summary>
        public virtual ICollection<PlanGroupPlan> MarkedOnGroupPlans { get; set; }

        /// <summary>
        /// Created plan group plans
        /// </summary>
        public virtual ICollection<PlanGroupPlan> CreatedPlanGroupPlans { get; set; }

        /// <summary>
        /// Last updated plan group plans
        /// </summary>
        public virtual ICollection<PlanGroupPlan> LastUpdatedPlanGroupPlans { get; set; }

        /// <summary>
        /// Created plan group comments
        /// </summary>
        public virtual ICollection<PlanGroupPlanComment> CreatedPlanGroupPlanComment { get; set; }

        /// <summary>
        /// Created user-plan groups
        /// </summary>
        public virtual ICollection<UserPlanGroup> Groups { get; set; }

        /// <summary>
        /// User-plan groups
        /// </summary>
        public virtual ICollection<UserPlanGroup> AddedUsersToGroups { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Notifications
        /// </summary>
        public virtual ICollection<Notification> Notifications { get; set; }

        /// <summary>
        /// Send friend requests
        /// </summary>
        public virtual ICollection<FriendRequest> SentFriendRequest { get; set; }

        /// <summary>
        /// Received friend requests
        /// </summary>
        public virtual ICollection<FriendRequest> ReceivedFriendRequest { get; set; }

        /// <summary>
        /// Friend list
        /// </summary>
        public virtual ICollection<Friends> FriendListLeft { get; set; }

        /// <summary>
        /// Friend list
        /// </summary>
        public virtual ICollection<Friends> FriendListRight { get; set; }

        /// <summary>
        /// Sent messages
        /// </summary>
        public virtual ICollection<Message> SentMessages { get; set; }

        /// <summary>
        /// Received messages
        /// </summary>
        public virtual ICollection<Message> ReceivedMessages { get; set; }

        /// <summary>
        /// Created news
        /// </summary>
        public virtual ICollection<News> CreatedNews { get; set; }

        /// <summary>
        /// Updated news
        /// </summary>
        public virtual ICollection<News> UpdatedNews { get; set; }

        /// <summary>
        /// Tasks
        /// </summary>
        public virtual ICollection<Task> Tasks { get; set; }

        /// <summary>
        /// Working days
        /// </summary>
        public virtual ICollection<WorkingDay> WorkingDays { get; set; }

        /// <summary>
        /// Create movies
        /// </summary>
        public virtual ICollection<Movie> CreatedMovies { get; set; }

        /// <summary>
        /// Last updated movies
        /// </summary>
        public virtual ICollection<Movie> LastUpdatedMovies { get; set; }

        /// <summary>
        /// My movies
        /// </summary>
        public virtual ICollection<UserMovie> MyMovies { get; set; }


        /// <summary>
        /// Created serieses
        /// </summary>
        public virtual ICollection<Series> CreatedSeries { get; set; }


        /// <summary>
        /// Last updated serieses
        /// </summary>
        public virtual ICollection<Series> LastUpdatedSeries { get; set; }


        /// <summary>
        /// My series
        /// </summary>
        public virtual ICollection<UserSeries> MySeries { get; set; }


        /// <summary>
        /// My episodes
        /// </summary>
        public virtual ICollection<UserEpisode> MyEpisodes { get; set; }


        /// <summary>
        /// Created books
        /// </summary>
        public virtual ICollection<Book> CreatedBooks { get; set; }


        /// <summary>
        /// Last updated books
        /// </summary>
        public virtual ICollection<Book> LastUpdatedBooks { get; set; }


        /// <summary>
        /// My books
        /// </summary>
        public virtual ICollection<UserBook> MyBooks { get; set; }


        /// <summary>
        /// Created movies comments
        /// </summary>
        public virtual ICollection<MovieComment> MovieComments { get; set; }

        /// <summary>
        /// Created series comments
        /// </summary>
        public virtual ICollection<SeriesComment> SeriesComments { get; set; }

        /// <summary>
        /// Last updated episodes
        /// </summary>
        public virtual ICollection<Episode> LastUpdatedEpisodes { get; set; }

        /// <summary>
        /// Owned csomors
        /// </summary>
        public virtual ICollection<Csomor> OwnedCsomors { get; set; }

        /// <summary>
        /// Last updated csomors
        /// </summary>
        public virtual ICollection<Csomor> LastUpdatedCsomors { get; set; }

        /// <summary>
        /// Shared csomors
        /// </summary>
        public virtual ICollection<UserCsomor> SharedCsomors { get; set; }
    }
}
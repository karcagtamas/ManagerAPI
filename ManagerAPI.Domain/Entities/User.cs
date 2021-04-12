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
    public class User : IdentityUser
    {
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public DateTime LastLogin { get; set; }

        [EmailAddress]
        public string SecondaryEmail { get; set; }

        [MaxLength(6)]
        public string TShirtSize { get; set; }

        public string Allergy { get; set; }

        [MaxLength(40)]
        public string Group { get; set; }

        public DateTime? BirthDay { get; set; }

        public string ProfileImageTitle { get; set; }

        public byte[] ProfileImageData { get; set; }

        [MaxLength(120)]
        public string Country { get; set; }

        public int? GenderId { get; set; }

        [MaxLength(120)]
        public string City { get; set; }

        public virtual ICollection<Plan> Plans { get; set; }
        public virtual ICollection<PlanGroup> CreatedPlanGroups { get; set; }
        public virtual ICollection<PlanGroup> LastUpdatedPlanGroups { get; set; }
        public virtual ICollection<PlanGroupIdea> CreatedPlanGroupIdeas { get; set; }
        public virtual ICollection<PlanGroupChatMessage> SentPlanGroupChatMessages { get; set; }
        public virtual ICollection<PlanGroupPlan> MarkedOnGroupPlans { get; set; }
        public virtual ICollection<PlanGroupPlan> CreatedPlanGroupPlans { get; set; }
        public virtual ICollection<PlanGroupPlan> LastUpdatedPlanGroupPlans { get; set; }
        public virtual ICollection<PlanGroupPlanComment> CreatedPlanGroupPlanComment { get; set; }
        public virtual ICollection<UserPlanGroup> Groups { get; set; }
        public virtual ICollection<UserPlanGroup> AddedUsersToGroups { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<FriendRequest> SentFriendRequest { get; set; }
        public virtual ICollection<FriendRequest> ReceivedFriendRequest { get; set; }
        public virtual ICollection<Friends> FriendListLeft { get; set; }
        public virtual ICollection<Friends> FriendListRight { get; set; }
        public virtual ICollection<Message> SentMessages { get; set; }
        public virtual ICollection<Message> ReceivedMessages { get; set; }
        public virtual ICollection<News> CreatedNews { get; set; }
        public virtual ICollection<News> UpdatedNews { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<WorkingDay> WorkingDays { get; set; }
        public virtual ICollection<Movie> CreatedMovies { get; set; }
        public virtual ICollection<Movie> LastUpdatedMovies { get; set; }
        public virtual ICollection<UserMovie> MyMovies { get; set; }
        public virtual ICollection<Series> CreatedSeries { get; set; }
        public virtual ICollection<Series> LastUpdatedSeries { get; set; }
        public virtual ICollection<UserSeries> MySeries { get; set; }
        public virtual ICollection<UserEpisode> MyEpisodes { get; set; }
        public virtual ICollection<Book> CreatedBooks { get; set; }
        public virtual ICollection<Book> LastUpdatedBooks { get; set; }
        public virtual ICollection<UserBook> MyBooks { get; set; }
        public virtual ICollection<MovieComment> MovieComments { get; set; }
        public virtual ICollection<SeriesComment> SeriesComments { get; set; }
        public virtual ICollection<Episode> LastUpdatedEpisodes { get; set; }
        public virtual ICollection<Csomor> OwnedCsomors { get; set; }
        public virtual ICollection<Csomor> LastUpdatedCsomors { get; set; }
        public virtual ICollection<UserCsomor> SharedCsomors { get; set; }
    }
}
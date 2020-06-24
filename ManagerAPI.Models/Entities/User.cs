using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EventManager.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace ManagerAPI.Models.Entities {
    public class User : IdentityUser {
        [MaxLength (100)]
        public string FullName { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [Column (TypeName = "datetime2")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [Column (TypeName = "datetime2")]
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
        public virtual ICollection<MasterEvent> CreatedMasterEvents { get; set; }
        public virtual ICollection<MasterEvent> UpdatedMasterEvents { get; set; }
        public virtual ICollection<UserEvent> Events { get; set; }
        public virtual ICollection<UserEvent> AddedUsersToEvents { get; set; }
        public virtual ICollection<UserEventRole> EventRoles { get; set; }
        public virtual ICollection<UserEventRole> AddedRolesToEvent { get; set; }
        public virtual ICollection<EventAction> CausedEventActions { get; set; }
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
    }
}
using ManagerAPI.Domain.Entities;
using ManagerAPI.Domain.Entities.CSM;
using ManagerAPI.Domain.Entities.PM;
using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Domain.Entities.WM;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ManagerAPI.DataAccess
{
    /// <summary>
    /// Database Context
    /// </summary>
    public class DatabaseContext : IdentityDbContext
    {
        /// <summary>
        /// Genders
        /// </summary>
        public DbSet<Gender> Genders { get; set; }

        /// <summary>
        /// AppUsers
        /// </summary>
        public DbSet<User> AppUsers { get; set; }

        /// <summary>
        /// AppRoles
        /// </summary>
        public DbSet<WebsiteRole> AppRoles { get; set; }

        /// <summary>
        /// NotificationSystems
        /// </summary>
        public DbSet<NotificationSystem> NotificationSystems { get; set; }

        /// <summary>
        /// NotificationTypes
        /// </summary>
        public DbSet<NotificationType> NotificationTypes { get; set; }

        /// <summary>
        /// Notifications
        /// </summary>
        public DbSet<Notification> Notifications { get; set; }

        /// <summary>
        /// FriendRequests
        /// </summary>
        public DbSet<FriendRequest> FriendRequests { get; set; }

        /// <summary>
        /// Friends
        /// </summary>
        public DbSet<Friends> Friends { get; set; }

        /// <summary>
        /// Messages
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        /// <summary>
        /// News
        /// </summary>
        public DbSet<News> News { get; set; }

        /// <summary>
        /// Tasks
        /// </summary>
        public DbSet<Task> Tasks { get; set; }

        // PM
        /// <summary>
        /// PlanTypes
        /// </summary>
        public DbSet<PlanType> PlanTypes { get; set; }

        /// <summary>
        /// Plans
        /// </summary>
        public DbSet<Plan> Plans { get; set; }

        /// <summary>
        /// PlanGroups
        /// </summary>
        public DbSet<PlanGroup> PlanGroups { get; set; }

        /// <summary>
        /// PlanGroupIdeas
        /// </summary>
        public DbSet<PlanGroupIdea> PlanGroupIdeas { get; set; }

        /// <summary>
        /// PlanGroupChatMessages
        /// </summary>
        public DbSet<PlanGroupChatMessage> PlanGroupChatMessages { get; set; }

        /// <summary>
        /// MarkTypes
        /// </summary>
        public DbSet<MarkType> MarkTypes { get; set; }

        /// <summary>
        /// PlanGroupPlans
        /// </summary>
        public DbSet<PlanGroupPlan> PlanGroupPlans { get; set; }

        /// <summary>
        /// PlanGroupPlanComments
        /// </summary>
        public DbSet<PlanGroupPlanComment> PlanGroupPlanComments { get; set; }

        /// <summary>
        /// GroupRoles
        /// </summary>
        public DbSet<GroupRole> GroupRoles { get; set; }

        /// <summary>
        /// UserPlanGroupsSwitch
        /// </summary>
        public DbSet<UserPlanGroup> UserPlanGroupsSwitch { get; set; }

        // WM
        /// <summary>
        /// WorkingDayTypes
        /// </summary>
        public DbSet<WorkingDayType> WorkingDayTypes { get; set; }

        /// <summary>
        /// WorkingDays
        /// </summary>
        public DbSet<WorkingDay> WorkingDays { get; set; }

        /// <summary>
        /// WorkingFields
        /// </summary>
        public DbSet<WorkingField> WorkingFields { get; set; }

        // SL
        /// <summary>
        /// MovieCategories
        /// </summary>
        public DbSet<MovieCategory> MovieCategories { get; set; }

        /// <summary>
        /// Movies
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// MovieComments
        /// </summary>
        public DbSet<MovieComment> MovieComments { get; set; }

        /// <summary>
        /// MovieMovieCategorySwitch
        /// </summary>
        public DbSet<MovieMovieCategory> MovieMovieCategorySwitch { get; set; }

        /// <summary>
        /// UserMovieSwitch
        /// </summary>
        public DbSet<UserMovie> UserMovieSwitch { get; set; }

        /// <summary>
        /// SeriesCategories
        /// </summary>
        public DbSet<SeriesCategory> SeriesCategories { get; set; }

        /// <summary>
        /// Series
        /// </summary>
        public DbSet<Series> Series { get; set; }

        /// <summary>
        /// SeriesComments
        /// </summary>
        public DbSet<SeriesComment> SeriesComments { get; set; }

        /// <summary>
        /// SeriesSeriesCategoriesSwitch
        /// </summary>
        public DbSet<SeriesSeriesCategory> SeriesSeriesCategoriesSwitch { get; set; }

        /// <summary>
        /// UserSeriesSwitch
        /// </summary>
        public DbSet<UserSeries> UserSeriesSwitch { get; set; }

        /// <summary>
        /// Seasons
        /// </summary>
        public DbSet<Season> Seasons { get; set; }

        /// <summary>
        /// Episodes
        /// </summary>
        public DbSet<Episode> Episodes { get; set; }

        /// <summary>
        /// UserEpisodeSwitch
        /// </summary>
        public DbSet<UserEpisode> UserEpisodeSwitch { get; set; }

        /// <summary>
        /// Books
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// UserBookSwitch
        /// </summary>
        public DbSet<UserBook> UserBookSwitch { get; set; }

        // CSM
        /// <summary>
        /// Csomors
        /// </summary>
        public DbSet<Csomor> Csomors { get; set; }

        /// <summary>
        /// CsomorPersons
        /// </summary>
        public DbSet<CsomorPerson> CsomorPersons { get; set; }

        /// <summary>
        /// CsomorWorks
        /// </summary>
        public DbSet<CsomorWork> CsomorWorks { get; set; }

        /// <summary>
        /// CsomorPersonTables
        /// </summary>
        public DbSet<CsomorPersonTable> CsomorPersonTables { get; set; }

        /// <summary>
        /// CsomorWorkTables
        /// </summary>
        public DbSet<CsomorWorkTable> CsomorWorkTables { get; set; }

        /// <summary>
        /// SharedCsomors
        /// </summary>
        public DbSet<UserCsomor> SharedCsomors { get; set; }

        /// <summary>
        /// IgnoredWorks
        /// </summary>
        public DbSet<IgnoredWork> IgnoredWorks { get; set; }

        /// <summary>
        /// Init DbContext
        /// </summary>
        /// <param name="options">Database context options</param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Gender table settings
            builder.Entity<Gender>()
                .HasData(new Gender { Id = 1, Name = "Male" });
            builder.Entity<Gender>()
                .HasData(new Gender { Id = 2, Name = "Female" });
            builder.Entity<Gender>()
                .HasData(new Gender { Id = 3, Name = "Other" });

            // User table settings
            builder.Entity<User>()
                .Property(x => x.LastLogin)
                .HasDefaultValueSql("NOW()");
            builder.Entity<User>()
                .Property(x => x.RegistrationDate)
                .HasDefaultValueSql("NOW()");
            builder.Entity<User>()
                .Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Entity<User>()
                .HasOne(x => x.Gender)
                .WithMany(x => x.Users)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasData(new User
                {
                    UserName = "karcagtamas",
                    Email = "karcagtamas@outlook.com",
                    Id = "44045506-66fd-4af8-9d59-133c47d1787c",
                    EmailConfirmed = true,
                    IsActive = true,
                    FullName = "Karcag Tamas",
                    NormalizedEmail = "KARCAGTAMAS@OUTLOOK.COM",
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEG9SljY4ow/I7990YZ15dSGvCesg0bad3pQSWi4ekt0RT8J5JuL3lQmNJCnxo2lGIA==",
                    NormalizedUserName = "KARCAGTAMAS"
                });
            builder.Entity<User>()
                .HasData(new User
                {
                    UserName = "aaronkaa",
                    Email = "aron.klenovszky@gmail.com",
                    Id = "f8237fac-c6dc-47b0-8f71-b72f93368b02",
                    EmailConfirmed = true,
                    IsActive = true,
                    FullName = "Klenovszky Áron",
                    NormalizedEmail = "ARON.KLENOVSZKY@GMAIL.COM",
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEL9QeDNFqEAq8WDl2/fXBSc02Tzxxnek963ILEw1L3aQsFysXXG4L3KvFYIVg/LpLA==",
                    NormalizedUserName = "AARONKAA"
                });
            builder.Entity<User>()
                .HasData(new User
                {
                    UserName = "root",
                    Email = "root@karcags.hu",
                    Id = "cd5e5069-59c8-4163-95c5-776fab95e51a",
                    EmailConfirmed = true,
                    IsActive = true,
                    FullName = "Root",
                    NormalizedEmail = "ROOT@KARCAGS.HU",
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEHdK+ODabrjejNLGhod4ftL37G5zT97p2g0Ck5dH9MchA2B/JFDiwb9kk9soZBPF5Q==",
                    NormalizedUserName = "ROOT"
                });
            builder.Entity<User>()
                .HasData(new User
                {
                    UserName = "barni363hun",
                    Email = "barni.pbs@gmail.com",
                    Id = "fa2edf69-5fc8-a163-9fc5-726f3b94e51b",
                    EmailConfirmed = true,
                    IsActive = true,
                    FullName = "Root",
                    NormalizedEmail = "BARNI.PBS@GMAIL.COM",
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEL9QeDNFqEAq8WDl2/fXBSc02Tzxxnek963ILEw1L3aQsFysXXG4L3KvFYIVg/LpLA==",
                    NormalizedUserName = "BARNI363HUN"
                });

            // Website table settings
            builder.Entity<WebsiteRole>()
                .HasData(new WebsiteRole
                {
                    Id = "2f76c2fc-bbca-41ff-86ed-5ef43d41d8f9",
                    AccessLevel = 0,
                    Name = "Visitor",
                    NormalizedName = "VISITOR"
                });
            builder.Entity<WebsiteRole>()
                .HasData(new WebsiteRole
                {
                    Id = "776474d7-8d01-4809-963e-c721f39dbb45",
                    AccessLevel = 1,
                    Name = "Normal",
                    NormalizedName = "NORMAL"
                });
            builder.Entity<WebsiteRole>()
                .HasData(new WebsiteRole
                {
                    Id = "5e0a9192-793f-4c85-a0b1-3198295bf409",
                    AccessLevel = 2,
                    Name = "Moderator",
                    NormalizedName = "MODERATOR"
                });
            builder.Entity<WebsiteRole>()
                .HasData(new WebsiteRole
                {
                    Id = "936e42dc-5d3f-4355-bc3a-304a4fe4f518",
                    AccessLevel = 3,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                });
            builder.Entity<WebsiteRole>().HasData(new List<WebsiteRole>
            {
                new WebsiteRole
                {
                    Id = "936e4ddc-5d3f-4355-af3a-304a4fe4f518",
                    AccessLevel = 1,
                    Name = "Status Library User",
                    NormalizedName = "STATUS LIBRARY USER"
                }
            });
            builder.Entity<WebsiteRole>().HasData(new List<WebsiteRole>
            {
                new WebsiteRole
                {
                    Id = "936e4ddc-5d3f-5466-af3a-3b4a4424d518",
                    AccessLevel = 3,
                    Name = "Status Library Moderator",
                    NormalizedName = "STATUS LIBRARY MODERATOR"
                }
            });
            builder.Entity<WebsiteRole>().HasData(new List<WebsiteRole>
            {
                new WebsiteRole
                {
                    Id = "936d4dfc-5536-4d5f-af2a-304d4fe4f518",
                    AccessLevel = 3,
                    Name = "Status Library Administrator",
                    NormalizedName = "STATUS LIBRARY ADMINISTRATOR"
                }
            });
            builder.Entity<WebsiteRole>()
                .HasData(new WebsiteRole
                {
                    Id = "fa5deb78-59c2-4faa-83dc-6c3369eedf20",
                    AccessLevel = 4,
                    Name = "Root",
                    NormalizedName = "ROOT"
                });

            // Notification system table settings
            builder.Entity<NotificationSystem>()
                .HasData(new NotificationSystem { Id = 1, Name = "System", ShortName = "Sys" });
            builder.Entity<NotificationSystem>()
                .HasData(new NotificationSystem { Id = 2, Name = "Event Manager", ShortName = "EM" });
            builder.Entity<NotificationSystem>()
                .HasData(new NotificationSystem { Id = 3, Name = "Plan Manager", ShortName = "PM" });
            builder.Entity<NotificationSystem>()
                .HasData(new NotificationSystem { Id = 4, Name = "Status Library", ShortName = "SL" });
            builder.Entity<NotificationSystem>()
                .HasData(new NotificationSystem { Id = 5, Name = "Work Manager", ShortName = "WM" });

            // Notification type table settings
            builder.Entity<NotificationType>()
                .HasOne(x => x.System)
                .WithMany(x => x.Types)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 1, Title = "Login", ImportanceLevel = 2, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 2, Title = "Registration", ImportanceLevel = 3, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 3, Title = "Logout", ImportanceLevel = 1, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 4, Title = "My Profile Updated", ImportanceLevel = 3, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 5, Title = "Message Arrived", ImportanceLevel = 1, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 6, Title = "ToDo Added", ImportanceLevel = 2, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 7, Title = "ToDo Deleted", ImportanceLevel = 2, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 8, Title = "ToDo Updated", ImportanceLevel = 1, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 9, Title = "Event Created", ImportanceLevel = 3, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 10, Title = "Event Disabled", ImportanceLevel = 3, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 11, Title = "Event Published", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 12, Title = "Event Locked", ImportanceLevel = 1, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 13, Title = "Event Updated", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 14, Title = "Event Message Arrived", ImportanceLevel = 1, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 15, Title = "Event Member Invited", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 16, Title = "Invitation Accepted", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 17, Title = "Invitation Declined", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 18, Title = "Invited To An Event", ImportanceLevel = 1, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 19, Title = "Accept Event Invitation", ImportanceLevel = 1, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 20, Title = "Decline Event Invitation", ImportanceLevel = 1, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 21, Title = "Event Member Removed", ImportanceLevel = 3, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 22, Title = "Removed From An Event", ImportanceLevel = 3, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 23, Title = "Event Evolved To Sport Event", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 24, Title = "Event Evolved To GT Event", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 25, Title = "Event Date Changed", ImportanceLevel = 1, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 26, Title = "Event Role Added", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 27, Title = "Event Role Updated", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 28, Title = "Event Role Deleted", ImportanceLevel = 3, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 29, Title = "Event Role Added To A User", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 30, Title = "Role Added In An Event", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 31, Title = "Event Role Removed From A User", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 32, Title = "Role Removed In An Event", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType { Id = 33, Title = "Event ToDo Added", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 34, Title = "Event ToDo Deleted", ImportanceLevel = 2, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 35, Title = "Event ToDo Updated", ImportanceLevel = 1, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 36, Title = "Event PayOut Added", ImportanceLevel = 3, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 37, Title = "Event PayOut Deleted", ImportanceLevel = 3, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 38, Title = "Event PayOut Updated", ImportanceLevel = 3, SystemId = 2 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 39, Title = "Password Changed", ImportanceLevel = 3, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 40, Title = "Profile Image Changed", ImportanceLevel = 1, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 41, Title = "Username Changed", ImportanceLevel = 2, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 42, Title = "Profile Disabled", ImportanceLevel = 3, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 43, Title = "Friend Request Received", ImportanceLevel = 2, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 44, Title = "Friend Request Sent", ImportanceLevel = 1, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 45, Title = "Friend Request Accepted", ImportanceLevel = 2, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 46, Title = "Friend Request Declined", ImportanceLevel = 2, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 47, Title = "You Has a new Friend", ImportanceLevel = 2, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 48, Title = "Friend Removed", ImportanceLevel = 3, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 49, Title = "News Added", ImportanceLevel = 2, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 50, Title = "News Updated", ImportanceLevel = 1, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 51, Title = "News Deleted", ImportanceLevel = 3, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 52, Title = "Working Field Added", ImportanceLevel = 1, SystemId = 5 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 53, Title = "Working Field Deleted", ImportanceLevel = 1, SystemId = 5 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 54, Title = "Working Field Updated", ImportanceLevel = 1, SystemId = 5 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 55, Title = "Working Day Added", ImportanceLevel = 1, SystemId = 5 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 56, Title = "Working Day Deleted", ImportanceLevel = 1, SystemId = 5 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 57, Title = "Working Day Updated", ImportanceLevel = 1, SystemId = 5 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 58, Title = "Working Day Type Added", ImportanceLevel = 2, SystemId = 5 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 59, Title = "Working Day Type Deleted", ImportanceLevel = 3, SystemId = 5 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 60, Title = "Working Day Type Updated", ImportanceLevel = 2, SystemId = 5 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 61, Title = "Message Added", ImportanceLevel = 1, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 62, Title = "Message Deleted", ImportanceLevel = 1, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 63, Title = "Message Updated", ImportanceLevel = 1, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 64, Title = "Gender Added", ImportanceLevel = 2, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 65, Title = "Gender Deleted", ImportanceLevel = 3, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 66, Title = "Gender Updated", ImportanceLevel = 2, SystemId = 1 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 67, Title = "Movie Added", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 68, Title = "Movie Deleted", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 69, Title = "Movie Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 70, Title = "Book Added", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 71, Title = "Book Deleted", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 72, Title = "Book Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 73, Title = "Book Read Status Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 74, Title = "My Book List Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 75, Title = "Movie Seen Status Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 76, Title = "My Movie List Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 77, Title = "Series Added", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 78, Title = "Series Deleted", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 79, Title = "Series Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 80, Title = "My Series List Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 81, Title = "Season Added", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 82, Title = "Season Deleted", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 83, Title = "Season Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 84, Title = "Episode Added", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 85, Title = "Episode Deleted", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 86, Title = "Episode Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 87, Title = "Episode Seen Status Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 88, Title = "Series Seen Status Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 89, Title = "Season Seen Status Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 90, Title = "Movie Category Added", ImportanceLevel = 2, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 91, Title = "Movie Category Deleted", ImportanceLevel = 2, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 92, Title = "Movie Category Updated", ImportanceLevel = 2, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 93, Title = "Movie Comment Added", ImportanceLevel = 2, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 94, Title = "Movie Comment Deleted", ImportanceLevel = 2, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 95, Title = "Movie Comment Updated", ImportanceLevel = 1, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 96, Title = "Series Category Added", ImportanceLevel = 2, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 97, Title = "Series Category Deleted", ImportanceLevel = 2, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 98, Title = "Series Category Updated", ImportanceLevel = 2, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 99, Title = "Series Comment Added", ImportanceLevel = 2, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 100, Title = "Series Comment Deleted", ImportanceLevel = 2, SystemId = 4 });
            builder.Entity<NotificationType>()
                .HasData(new NotificationType
                { Id = 101, Title = "Series Comment Updated", ImportanceLevel = 1, SystemId = 4 });

            // Notification table settings
            builder.Entity<Notification>()
                .HasOne(x => x.Type)
                .WithMany(x => x.Notifications)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Notification>()
                .HasOne(x => x.Owner)
                .WithMany(x => x.Notifications)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Notification>()
                .Property(x => x.Archived)
                .HasDefaultValue(false);
            builder.Entity<Notification>()
                .Property(x => x.IsRead)
                .HasDefaultValue(false);
            builder.Entity<Notification>()
                .Property(x => x.SentDate)
                .HasDefaultValueSql("NOW()");

            // Friend request table settings
            builder.Entity<FriendRequest>()
                .Property(x => x.ResponseDate)
                .HasDefaultValueSql("NOW()");
            builder.Entity<FriendRequest>()
                .Property(x => x.SentDate)
                .HasDefaultValueSql("NOW()");

            builder.Entity<FriendRequest>()
                .HasOne(x => x.Destination)
                .WithMany(x => x.ReceivedFriendRequest)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<FriendRequest>()
                .HasOne(x => x.Sender)
                .WithMany(x => x.SentFriendRequest)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Friends table settings
            builder.Entity<Friends>()
                .HasKey(x => new { x.UserId, x.FriendId });
            builder.Entity<Friends>()
                .Property(x => x.ConnectionDate)
                .HasDefaultValueSql("NOW()");
            builder.Entity<Friends>()
                .HasOne(x => x.User)
                .WithMany(x => x.FriendListLeft)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Friends>()
                .HasOne(x => x.Friend)
                .WithMany(x => x.FriendListRight)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Friends>()
                .HasOne(x => x.Request)
                .WithMany(x => x.FriendCollection)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Message table settings
            builder.Entity<Message>()
                .Property(x => x.Date)
                .HasDefaultValueSql("NOW()");
            builder.Entity<Message>()
                .HasOne(x => x.Sender)
                .WithMany(x => x.SentMessages)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Message>()
                .HasOne(x => x.Receiver)
                .WithMany(x => x.ReceivedMessages)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // News table settings
            builder.Entity<News>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("NOW()");
            builder.Entity<News>()
                .Property(x => x.LastUpdate)
                .HasDefaultValueSql("NOW()");
            builder.Entity<News>()
                .HasOne(x => x.Creator)
                .WithMany(x => x.CreatedNews)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<News>()
                .HasOne(x => x.LastUpdater)
                .WithMany(x => x.UpdatedNews)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Task table settings
            builder.Entity<Task>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("NOW()");
            builder.Entity<Task>()
                .Property(x => x.LastUpdate)
                .HasDefaultValueSql("NOW()");
            builder.Entity<Task>()
                .Property(x => x.IsSolved)
                .HasDefaultValue(false);
            builder.Entity<Task>()
                .HasOne(x => x.Owner)
                .WithMany(x => x.Tasks)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Plan type table settings
            builder.Entity<PlanType>()
                .HasData(new PlanType { Id = 1, Name = "Plan" });
            builder.Entity<PlanType>()
                .HasData(new PlanType { Id = 2, Name = "Future Idea" });
            builder.Entity<PlanType>()
                .HasData(new PlanType { Id = 3, Name = "Nice To Have" });
            builder.Entity<PlanType>()
                .HasData(new PlanType { Id = 4, Name = "Learning" });
            builder.Entity<PlanType>()
                .HasData(new PlanType { Id = 5, Name = "Decision" });
            builder.Entity<PlanType>()
                .HasData(new PlanType { Id = 6, Name = "Event" });

            // Plan table settings
            builder.Entity<Plan>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("NOW()");
            builder.Entity<Plan>()
                .Property(x => x.EndTime)
                .HasDefaultValueSql("NOW()");
            builder.Entity<Plan>()
                .Property(x => x.LastUpdate)
                .HasDefaultValueSql("NOW()");
            builder.Entity<Plan>()
                .Property(x => x.StartTime)
                .HasDefaultValueSql("NOW()");
            builder.Entity<Plan>()
                .Property(x => x.IsPublic)
                .HasDefaultValue(false);
            builder.Entity<Plan>()
                .HasOne(x => x.Owner)
                .WithMany(x => x.Plans)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<Plan>()
                .HasOne(x => x.PlanType)
                .WithMany(x => x.Plans)
                .OnDelete(DeleteBehavior.ClientCascade);

            // Plan group table settings
            builder.Entity<PlanGroup>()
                .Property(x => x.LastUpdate)
                .HasDefaultValueSql("NOW()");
            builder.Entity<PlanGroup>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("NOW()");
            builder.Entity<PlanGroup>()
                .HasOne(x => x.Creator)
                .WithMany(x => x.CreatedPlanGroups)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<PlanGroup>()
                .HasOne(x => x.LastUpdater)
                .WithMany(x => x.LastUpdatedPlanGroups)
                .OnDelete(DeleteBehavior.ClientNoAction);

            // Plan group idea table settings
            builder.Entity<PlanGroupIdea>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("NOW()");
            builder.Entity<PlanGroupIdea>()
                .HasOne(x => x.Creator)
                .WithMany(x => x.CreatedPlanGroupIdeas)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<PlanGroupIdea>()
                .HasOne(x => x.Group)
                .WithMany(x => x.Ideas)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            // Plan group message table settings
            builder.Entity<PlanGroupChatMessage>()
                .Property(x => x.Sent)
                .HasDefaultValueSql("NOW()");
            builder.Entity<PlanGroupChatMessage>()
                .HasOne(x => x.Sender)
                .WithMany(x => x.SentPlanGroupChatMessages)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<PlanGroupChatMessage>()
                .HasOne(x => x.Group)
                .WithMany(x => x.Messages)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            // Mark type table settings
            builder.Entity<MarkType>()
                .HasData(new MarkType { Id = 1, Title = "Responsible" });
            builder.Entity<MarkType>()
                .HasData(new MarkType { Id = 2, Title = "Owner" });
            builder.Entity<MarkType>()
                .HasData(new MarkType { Id = 3, Title = "Modifier" });
            builder.Entity<MarkType>()
                .HasData(new MarkType { Id = 4, Title = "Leader" });

            // Plan group plan table settings
            builder.Entity<PlanGroupPlan>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("NOW()");
            builder.Entity<PlanGroupPlan>()
                .Property(x => x.LastUpdate)
                .HasDefaultValueSql("NOW()");
            builder.Entity<PlanGroupPlan>()
                .Property(x => x.IsPublic)
                .HasDefaultValue(false);
            builder.Entity<PlanGroupPlan>()
                .HasOne(x => x.Owner)
                .WithMany(x => x.CreatedPlanGroupPlans)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<PlanGroupPlan>()
                .HasOne(x => x.LastUpdater)
                .WithMany(x => x.LastUpdatedPlanGroupPlans)
                .OnDelete(DeleteBehavior.ClientNoAction);
            builder.Entity<PlanGroupPlan>()
                .HasOne(x => x.PlanType)
                .WithMany(x => x.GroupPlans)
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<PlanGroupPlan>()
                .HasOne(x => x.MarkedUser)
                .WithMany(x => x.MarkedOnGroupPlans)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<PlanGroupPlan>()
                .HasOne(x => x.MarkType)
                .WithMany(x => x.MarkedPlans)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<PlanGroupPlan>()
                .HasOne(x => x.Group)
                .WithMany(x => x.Plans)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            // Plan group plan comment table settings
            builder.Entity<PlanGroupPlanComment>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("NOW()");
            builder.Entity<PlanGroupPlanComment>()
                .HasOne(x => x.Sender)
                .WithMany(x => x.CreatedPlanGroupPlanComment)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<PlanGroupPlanComment>()
                .HasOne(x => x.Plan)
                .WithMany(x => x.Comments)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            // Group role table settings
            builder.Entity<GroupRole>()
                .HasData(new GroupRole { Id = 1, Title = "Visitor", AccessLevel = 0 });
            builder.Entity<GroupRole>()
                .HasData(new GroupRole { Id = 2, Title = "Normal", AccessLevel = 1 });
            builder.Entity<GroupRole>()
                .HasData(new GroupRole { Id = 3, Title = "Editor", AccessLevel = 2 });
            builder.Entity<GroupRole>()
                .HasData(new GroupRole { Id = 4, Title = "Moderator", AccessLevel = 3 });
            builder.Entity<GroupRole>()
                .HasData(new GroupRole { Id = 5, Title = "Administrator", AccessLevel = 4 });
            builder.Entity<GroupRole>()
                .HasData(new GroupRole { Id = 6, Title = "Owner", AccessLevel = 5 });

            // User - Plan group switch table settings
            builder.Entity<UserPlanGroup>()
                .HasKey(x => new { x.UserId, x.GroupId });
            builder.Entity<UserPlanGroup>()
                .Property(x => x.Connection)
                .HasDefaultValueSql("NOW()");
            builder.Entity<UserPlanGroup>()
                .HasOne(x => x.User)
                .WithMany(x => x.Groups)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<UserPlanGroup>()
                .HasOne(x => x.Group)
                .WithMany(x => x.Users)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<UserPlanGroup>()
                .HasOne(x => x.Role)
                .WithMany(x => x.GroupMembers)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<UserPlanGroup>()
                .HasOne(x => x.AddedBy)
                .WithMany(x => x.AddedUsersToGroups)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            // Working Day types table settings
            builder.Entity<WorkingDayType>()
                .Property(x => x.DayIsActive)
                .HasDefaultValue(false);

            builder.Entity<WorkingDayType>()
                .HasData(new WorkingDayType { Id = 1, Title = "Work Day", DayIsActive = true });
            builder.Entity<WorkingDayType>()
                .HasData(new WorkingDayType { Id = 2, Title = "University", DayIsActive = false });
            builder.Entity<WorkingDayType>()
                .HasData(new WorkingDayType { Id = 3, Title = "Empty Day", DayIsActive = false });
            builder.Entity<WorkingDayType>()
                .HasData(new WorkingDayType { Id = 4, Title = "Holiday", DayIsActive = false });


            // Working Day table settings
            builder.Entity<WorkingDay>()
                .HasOne(x => x.Type)
                .WithMany(x => x.WorkingDays)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WorkingDay>()
                .HasOne(x => x.User)
                .WithMany(x => x.WorkingDays)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Working Field table settings
            builder.Entity<WorkingField>()
                .HasOne(x => x.WorkingDay)
                .WithMany(x => x.WorkingFields)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Movie categories table settings
            builder.Entity<MovieCategory>()
                .HasData(new List<MovieCategory>
                {
                    new MovieCategory
                    {
                        Id = 1,
                        Name = "Drama"
                    },
                    new MovieCategory
                    {
                        Id = 2,
                        Name = "Action"
                    },
                    new MovieCategory
                    {
                        Id = 3,
                        Name = "Romantic"
                    },
                    new MovieCategory
                    {
                        Id = 4,
                        Name = "Sci-fi"
                    }
                });

            // Movies table settings
            builder.Entity<Movie>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("NOW()");
            builder.Entity<Movie>()
                .Property(x => x.LastUpdate)
                .HasDefaultValueSql("NOW()");

            builder.Entity<Movie>()
                .HasOne(x => x.Creator)
                .WithMany(x => x.CreatedMovies)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Movie>()
                .HasOne(x => x.LastUpdater)
                .WithMany(x => x.LastUpdatedMovies)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Movie comment table settings
            builder.Entity<MovieComment>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("NOW()");
            builder.Entity<MovieComment>()
                .Property(x => x.LastUpdate)
                .HasDefaultValueSql("NOW()");

            builder.Entity<MovieComment>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.Comments)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<MovieComment>()
                .HasOne(x => x.User)
                .WithMany(x => x.MovieComments)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Movie - Movie category switch
            builder.Entity<MovieMovieCategory>()
                .HasKey(x => new { x.MovieId, x.CategoryId });

            builder.Entity<MovieMovieCategory>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.Categories)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<MovieMovieCategory>()
                .HasOne(x => x.Category)
                .WithMany(x => x.ConnectedMovies)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // User movie settings
            builder.Entity<UserMovie>()
                .HasKey(x => new { x.UserId, x.MovieId });

            builder.Entity<UserMovie>()
                .Property(x => x.IsSeen)
                .HasDefaultValue(false);
            builder.Entity<UserMovie>()
                .Property(x => x.AddedOn)
                .HasDefaultValueSql("NOW()");

            builder.Entity<UserMovie>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.ConnectedUsers)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserMovie>()
                .HasOne(x => x.User)
                .WithMany(x => x.MyMovies)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Series category table settings
            builder.Entity<SeriesCategory>()
                .HasData(new List<SeriesCategory>
                {
                    new SeriesCategory
                    {
                        Id = 1,
                        Name = "Drama"
                    },
                    new SeriesCategory
                    {
                        Id = 2,
                        Name = "Action"
                    },
                    new SeriesCategory
                    {
                        Id = 3,
                        Name = "Romantic"
                    },
                    new SeriesCategory
                    {
                        Id = 4,
                        Name = "Sci-fi"
                    }
                });

            // Series table settings
            builder.Entity<Series>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("NOW()");
            builder.Entity<Series>()
                .Property(x => x.LastUpdate)
                .HasDefaultValueSql("NOW()");

            builder.Entity<Series>()
                .HasOne(x => x.Creator)
                .WithMany(x => x.CreatedSeries)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Series>()
                .HasOne(x => x.LastUpdater)
                .WithMany(x => x.LastUpdatedSeries)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Series comment table settings
            builder.Entity<SeriesComment>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("NOW()");
            builder.Entity<SeriesComment>()
                .Property(x => x.LastUpdate)
                .HasDefaultValueSql("NOW()");

            builder.Entity<SeriesComment>()
                .HasOne(x => x.Series)
                .WithMany(x => x.Comments)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<SeriesComment>()
                .HasOne(x => x.User)
                .WithMany(x => x.SeriesComments)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Movie - Movie category switch
            builder.Entity<SeriesSeriesCategory>()
                .HasKey(x => new { x.SeriesId, x.CategoryId });

            builder.Entity<SeriesSeriesCategory>()
                .HasOne(x => x.Series)
                .WithMany(x => x.Categories)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<SeriesSeriesCategory>()
                .HasOne(x => x.Category)
                .WithMany(x => x.ConnectedSeriesList)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // User Series table settings
            builder.Entity<UserSeries>()
                .HasKey(x => new { x.UserId, x.SeriesId });

            builder.Entity<UserSeries>()
                .Property(x => x.AddedOn)
                .HasDefaultValueSql("NOW()");

            builder.Entity<UserSeries>()
                .HasOne(x => x.Series)
                .WithMany(x => x.ConnectedUsers)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserSeries>()
                .HasOne(x => x.User)
                .WithMany(x => x.MySeries)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Season table settings
            builder.Entity<Season>()
                .HasOne(x => x.Series)
                .WithMany(x => x.Seasons)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Episode table settings
            builder.Entity<Episode>()
                .HasOne(x => x.Season)
                .WithMany(x => x.Episodes)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Episode>()
                .HasOne(x => x.LastUpdater)
                .WithMany(x => x.LastUpdatedEpisodes)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // User Episode table settings
            builder.Entity<UserEpisode>()
                .HasKey(x => new { x.UserId, x.EpisodeId });

            builder.Entity<UserEpisode>()
                .Property(x => x.Seen)
                .HasDefaultValue(false);

            builder.Entity<UserEpisode>()
                .HasOne(x => x.Episode)
                .WithMany(x => x.ConnectedUsers)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserEpisode>()
                .HasOne(x => x.User)
                .WithMany(x => x.MyEpisodes)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Book table settings
            builder.Entity<Book>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("NOW()");
            builder.Entity<Book>()
                .Property(x => x.LastUpdate)
                .HasDefaultValueSql("NOW()");

            builder.Entity<Book>()
                .HasOne(x => x.Creator)
                .WithMany(x => x.CreatedBooks)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Book>()
                .HasOne(x => x.LastUpdater)
                .WithMany(x => x.LastUpdatedBooks)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // User Book table settings
            builder.Entity<UserBook>()
                .HasKey(x => new { x.UserId, x.BookId });

            builder.Entity<UserBook>()
                .Property(x => x.Read)
                .HasDefaultValue(false);
            builder.Entity<UserBook>()
                .Property(x => x.AddOn)
                .HasDefaultValueSql("NOW()");

            builder.Entity<UserBook>()
                .HasOne(x => x.Book)
                .WithMany(x => x.ConnectedUsers)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<UserBook>()
                .HasOne(x => x.User)
                .WithMany(x => x.MyBooks)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Csomor table settings
            builder.Entity<Csomor>()
                .Property(x => x.Creation)
                .HasDefaultValueSql("NOW()");
            builder.Entity<Csomor>()
                .Property(x => x.LastUpdate)
                .HasDefaultValueSql("NOW()");
            builder.Entity<Csomor>()
                .Property(x => x.IsShared)
                .HasDefaultValue(false);
            builder.Entity<Csomor>()
                .Property(x => x.IsPublic)
                .HasDefaultValue(false);
            builder.Entity<Csomor>()
                .Property(x => x.HasGeneratedCsomor)
                .HasDefaultValue(false);

            builder.Entity<Csomor>()
                .HasOne(x => x.Owner)
                .WithMany(x => x.OwnedCsomors)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Csomor>()
                .HasOne(x => x.LastUpdater)
                .WithMany(x => x.LastUpdatedCsomors)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // Csomor Person table settings
            builder.Entity<CsomorPerson>()
                .Property(x => x.IsIgnored)
                .HasDefaultValue(false);
            builder.Entity<CsomorPerson>()
                .Property(x => x.PlusWorkCounter)
                .HasDefaultValue(0);

            builder.Entity<CsomorPerson>()
                .HasOne(x => x.Csomor)
                .WithMany(x => x.Persons)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            // Csomor Work table settings
            builder.Entity<CsomorWork>()
                .HasOne(x => x.Csomor)
                .WithMany(x => x.Works)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            // Csomor Person Table table settings
            builder.Entity<CsomorPersonTable>()
                .Property(x => x.IsAvailable)
                .HasDefaultValue(false);

            builder.Entity<CsomorPersonTable>()
                .HasOne(x => x.Person)
                .WithMany(x => x.Tables)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<CsomorPersonTable>()
                .HasOne(x => x.Work)
                .WithMany(x => x.Persons)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // Csomor Work Table table settings
            builder.Entity<CsomorWorkTable>()
                .Property(x => x.IsActive)
                .HasDefaultValue(false);

            builder.Entity<CsomorWorkTable>()
                .HasOne(x => x.Work)
                .WithMany(x => x.Tables)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<CsomorWorkTable>()
                .HasOne(x => x.Person)
                .WithMany(x => x.Works)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // User Csomor
            builder.Entity<UserCsomor>()
                .HasKey(x => new { x.UserId, x.CsomorId });

            builder.Entity<UserCsomor>()
                .Property(x => x.HasWriteAccess)
                .HasDefaultValue(false);
            builder.Entity<UserCsomor>()
                .Property(x => x.SharedOn)
                .HasDefaultValueSql("NOW()");

            builder.Entity<UserCsomor>()
                .HasOne(x => x.User)
                .WithMany(x => x.SharedCsomors)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<UserCsomor>()
                .HasOne(x => x.Csomor)
                .WithMany(x => x.SharedWith)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);

            // Ignored Work table settings
            builder.Entity<IgnoredWork>()
                .HasKey(x => new { x.PersonId, x.WorkId });

            builder.Entity<IgnoredWork>()
                .HasOne(x => x.Person)
                .WithMany(x => x.IgnoredWorks)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.Entity<IgnoredWork>()
                .HasOne(x => x.Work)
                .WithMany(x => x.IgnoringPersons)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
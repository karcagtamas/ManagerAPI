CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;

CREATE TABLE `AspNetRoles` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Discriminator` longtext CHARACTER SET utf8mb4 NOT NULL,
    `AccessLevel` int NULL,
    `Name` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetRoles` PRIMARY KEY (`Id`)
);

CREATE TABLE `Genders` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Genders` PRIMARY KEY (`Id`)
);

CREATE TABLE `GroupRoles` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` longtext CHARACTER SET utf8mb4 NOT NULL,
    `AccessLevel` int NOT NULL,
    CONSTRAINT `PK_GroupRoles` PRIMARY KEY (`Id`)
);

CREATE TABLE `MarkTypes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(120) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_MarkTypes` PRIMARY KEY (`Id`)
);

CREATE TABLE `MovieCategories` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(120) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_MovieCategories` PRIMARY KEY (`Id`)
);

CREATE TABLE `NotificationSystems` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ShortName` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_NotificationSystems` PRIMARY KEY (`Id`)
);

CREATE TABLE `PlanTypes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_PlanTypes` PRIMARY KEY (`Id`)
);

CREATE TABLE `SeriesCategories` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(120) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_SeriesCategories` PRIMARY KEY (`Id`)
);

CREATE TABLE `WorkingDayTypes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `DayIsActive` tinyint(1) NOT NULL DEFAULT FALSE,
    CONSTRAINT `PK_WorkingDayTypes` PRIMARY KEY (`Id`)
);

CREATE TABLE `AspNetRoleClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
    `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetRoleClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUsers` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Discriminator` longtext CHARACTER SET utf8mb4 NOT NULL,
    `FullName` varchar(100) CHARACTER SET utf8mb4 NULL,
    `IsActive` tinyint(1) NULL DEFAULT TRUE,
    `RegistrationDate` datetime(6) NULL DEFAULT NOW(),
    `LastLogin` datetime(6) NULL DEFAULT NOW(),
    `SecondaryEmail` longtext CHARACTER SET utf8mb4 NULL,
    `TShirtSize` varchar(6) CHARACTER SET utf8mb4 NULL,
    `Allergy` longtext CHARACTER SET utf8mb4 NULL,
    `Group` varchar(40) CHARACTER SET utf8mb4 NULL,
    `BirthDay` datetime(6) NULL,
    `ProfileImageTitle` longtext CHARACTER SET utf8mb4 NULL,
    `ProfileImageData` longblob NULL,
    `Country` varchar(120) CHARACTER SET utf8mb4 NULL,
    `GenderId` int NULL,
    `City` varchar(120) CHARACTER SET utf8mb4 NULL,
    `UserName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 NULL,
    `Email` varchar(256) CHARACTER SET utf8mb4 NULL,
    `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 NULL,
    `EmailConfirmed` tinyint(1) NOT NULL,
    `PasswordHash` longtext CHARACTER SET utf8mb4 NULL,
    `SecurityStamp` longtext CHARACTER SET utf8mb4 NULL,
    `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 NULL,
    `PhoneNumber` longtext CHARACTER SET utf8mb4 NULL,
    `PhoneNumberConfirmed` tinyint(1) NOT NULL,
    `TwoFactorEnabled` tinyint(1) NOT NULL,
    `LockoutEnd` datetime(6) NULL,
    `LockoutEnabled` tinyint(1) NOT NULL,
    `AccessFailedCount` int NOT NULL,
    CONSTRAINT `PK_AspNetUsers` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetUsers_Genders_GenderId` FOREIGN KEY (`GenderId`) REFERENCES `Genders` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `NotificationTypes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ImportanceLevel` int NOT NULL,
    `SystemId` int NOT NULL,
    CONSTRAINT `PK_NotificationTypes` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_NotificationTypes_NotificationSystems_SystemId` FOREIGN KEY (`SystemId`) REFERENCES `NotificationSystems` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ClaimType` longtext CHARACTER SET utf8mb4 NULL,
    `ClaimValue` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetUserClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserLogins` (
    `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ProviderKey` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ProviderDisplayName` longtext CHARACTER SET utf8mb4 NULL,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_AspNetUserLogins` PRIMARY KEY (`LoginProvider`, `ProviderKey`),
    CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserRoles` (
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_AspNetUserRoles` PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserTokens` (
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Value` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_AspNetUserTokens` PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
    CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Books` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `Author` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    `Publish` datetime(6) NULL,
    `CreatorId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `LastUpdaterId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Creation` datetime(6) NOT NULL DEFAULT NOW(),
    `LastUpdate` datetime(6) NOT NULL DEFAULT NOW(),
    CONSTRAINT `PK_Books` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Books_AspNetUsers_CreatorId` FOREIGN KEY (`CreatorId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Books_AspNetUsers_LastUpdaterId` FOREIGN KEY (`LastUpdaterId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Csomors` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(120) CHARACTER SET utf8mb4 NOT NULL,
    `Creation` datetime(6) NOT NULL DEFAULT NOW(),
    `OwnerId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `LastUpdate` datetime(6) NULL DEFAULT NOW(),
    `LastUpdaterId` varchar(255) CHARACTER SET utf8mb4 NULL,
    `Start` datetime(6) NOT NULL,
    `Finish` datetime(6) NOT NULL,
    `MaxWorkHour` int NOT NULL,
    `MinRestHour` int NOT NULL,
    `IsShared` tinyint(1) NOT NULL DEFAULT FALSE,
    `IsPublic` tinyint(1) NOT NULL DEFAULT FALSE,
    `HasGeneratedCsomor` tinyint(1) NOT NULL DEFAULT FALSE,
    `LastGeneration` datetime(6) NULL,
    CONSTRAINT `PK_Csomors` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Csomors_AspNetUsers_LastUpdaterId` FOREIGN KEY (`LastUpdaterId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Csomors_AspNetUsers_OwnerId` FOREIGN KEY (`OwnerId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `FriendRequests` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `SenderId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `DestinationId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `SentDate` datetime(6) NOT NULL DEFAULT NOW(),
    `Message` varchar(120) CHARACTER SET utf8mb4 NOT NULL,
    `Response` tinyint(1) NULL,
    `ResponseDate` datetime(6) NULL DEFAULT NOW(),
    CONSTRAINT `PK_FriendRequests` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_FriendRequests_AspNetUsers_DestinationId` FOREIGN KEY (`DestinationId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_FriendRequests_AspNetUsers_SenderId` FOREIGN KEY (`SenderId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Messages` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Text` nvarchar(400) NOT NULL,
    `SenderId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ReceiverId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Date` datetime(6) NOT NULL DEFAULT NOW(),
    CONSTRAINT `PK_Messages` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Messages_AspNetUsers_ReceiverId` FOREIGN KEY (`ReceiverId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Messages_AspNetUsers_SenderId` FOREIGN KEY (`SenderId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Movies` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(999) CHARACTER SET utf8mb4 NULL,
    `ReleaseYear` int NULL,
    `Length` int NULL,
    `Director` varchar(60) CHARACTER SET utf8mb4 NULL,
    `TrailerUrl` varchar(200) CHARACTER SET utf8mb4 NULL,
    `ImageTitle` varchar(100) CHARACTER SET utf8mb4 NULL,
    `ImageData` longblob NULL,
    `CreatorId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `LastUpdaterId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Creation` datetime(6) NOT NULL DEFAULT NOW(),
    `LastUpdate` datetime(6) NOT NULL DEFAULT NOW(),
    CONSTRAINT `PK_Movies` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Movies_AspNetUsers_CreatorId` FOREIGN KEY (`CreatorId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Movies_AspNetUsers_LastUpdaterId` FOREIGN KEY (`LastUpdaterId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `News` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Content` varchar(512) CHARACTER SET utf8mb4 NOT NULL,
    `CreatorId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Creation` datetime(6) NOT NULL DEFAULT NOW(),
    `LastUpdaterId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `LastUpdate` datetime(6) NOT NULL DEFAULT NOW(),
    CONSTRAINT `PK_News` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_News_AspNetUsers_CreatorId` FOREIGN KEY (`CreatorId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_News_AspNetUsers_LastUpdaterId` FOREIGN KEY (`LastUpdaterId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `PlanGroups` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `CreatorId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Creation` datetime(6) NOT NULL DEFAULT NOW(),
    `LastUpdaterId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `LastUpdate` datetime(6) NOT NULL DEFAULT NOW(),
    `IsArchived` tinyint(1) NOT NULL,
    CONSTRAINT `PK_PlanGroups` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PlanGroups_AspNetUsers_CreatorId` FOREIGN KEY (`CreatorId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_PlanGroups_AspNetUsers_LastUpdaterId` FOREIGN KEY (`LastUpdaterId`) REFERENCES `AspNetUsers` (`Id`)
);

CREATE TABLE `Plans` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(512) CHARACTER SET utf8mb4 NULL,
    `OwnerId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Creation` datetime(6) NOT NULL DEFAULT NOW(),
    `LastUpdate` datetime(6) NOT NULL DEFAULT NOW(),
    `StartTime` datetime(6) NOT NULL DEFAULT NOW(),
    `EndTime` datetime(6) NULL DEFAULT NOW(),
    `PriorityLevel` int NULL,
    `IsPublic` tinyint(1) NOT NULL DEFAULT FALSE,
    `PlanTypeId` int NULL,
    CONSTRAINT `PK_Plans` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Plans_AspNetUsers_OwnerId` FOREIGN KEY (`OwnerId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Plans_PlanTypes_PlanTypeId` FOREIGN KEY (`PlanTypeId`) REFERENCES `PlanTypes` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Series` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(999) CHARACTER SET utf8mb4 NULL,
    `StartYear` int NULL,
    `EndYear` int NULL,
    `TrailerUrl` varchar(200) CHARACTER SET utf8mb4 NULL,
    `ImageTitle` varchar(100) CHARACTER SET utf8mb4 NULL,
    `ImageData` longblob NULL,
    `Creation` datetime(6) NOT NULL DEFAULT NOW(),
    `LastUpdate` datetime(6) NOT NULL DEFAULT NOW(),
    `CreatorId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `LastUpdaterId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Series` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Series_AspNetUsers_CreatorId` FOREIGN KEY (`CreatorId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Series_AspNetUsers_LastUpdaterId` FOREIGN KEY (`LastUpdaterId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Tasks` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
    `Description` longtext CHARACTER SET utf8mb4 NOT NULL,
    `IsSolved` tinyint(1) NOT NULL DEFAULT FALSE,
    `OwnerId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Creation` datetime(6) NOT NULL DEFAULT NOW(),
    `LastUpdate` datetime(6) NOT NULL DEFAULT NOW(),
    `Deadline` datetime(6) NOT NULL,
    CONSTRAINT `PK_Tasks` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Tasks_AspNetUsers_OwnerId` FOREIGN KEY (`OwnerId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `WorkingDays` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Day` datetime(6) NOT NULL,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `TypeId` int NOT NULL,
    CONSTRAINT `PK_WorkingDays` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_WorkingDays_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_WorkingDays_WorkingDayTypes_TypeId` FOREIGN KEY (`TypeId`) REFERENCES `WorkingDayTypes` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Notifications` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Content` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `SentDate` datetime(6) NOT NULL DEFAULT NOW(),
    `OwnerId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `IsRead` tinyint(1) NOT NULL DEFAULT FALSE,
    `Archived` tinyint(1) NOT NULL DEFAULT FALSE,
    `TypeId` int NOT NULL,
    CONSTRAINT `PK_Notifications` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Notifications_AspNetUsers_OwnerId` FOREIGN KEY (`OwnerId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Notifications_NotificationTypes_TypeId` FOREIGN KEY (`TypeId`) REFERENCES `NotificationTypes` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `UserBookSwitch` (
    `BookId` int NOT NULL,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Read` tinyint(1) NOT NULL DEFAULT FALSE,
    `ReadOn` datetime(6) NULL,
    `AddOn` datetime(6) NOT NULL DEFAULT NOW(),
    CONSTRAINT `PK_UserBookSwitch` PRIMARY KEY (`UserId`, `BookId`),
    CONSTRAINT `FK_UserBookSwitch_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_UserBookSwitch_Books_BookId` FOREIGN KEY (`BookId`) REFERENCES `Books` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `CsomorPersons` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Name` varchar(120) CHARACTER SET utf8mb4 NOT NULL,
    `CsomorId` int NOT NULL,
    `PlusWorkCounter` int NOT NULL DEFAULT 0,
    `IsIgnored` tinyint(1) NOT NULL DEFAULT FALSE,
    CONSTRAINT `PK_CsomorPersons` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_CsomorPersons_Csomors_CsomorId` FOREIGN KEY (`CsomorId`) REFERENCES `Csomors` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `CsomorWorks` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Name` varchar(80) CHARACTER SET utf8mb4 NOT NULL,
    `CsomorId` int NOT NULL,
    CONSTRAINT `PK_CsomorWorks` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_CsomorWorks_Csomors_CsomorId` FOREIGN KEY (`CsomorId`) REFERENCES `Csomors` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `SharedCsomors` (
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `CsomorId` int NOT NULL,
    `SharedOn` datetime(6) NOT NULL DEFAULT NOW(),
    `HasWriteAccess` tinyint(1) NOT NULL DEFAULT FALSE,
    CONSTRAINT `PK_SharedCsomors` PRIMARY KEY (`UserId`, `CsomorId`),
    CONSTRAINT `FK_SharedCsomors_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_SharedCsomors_Csomors_CsomorId` FOREIGN KEY (`CsomorId`) REFERENCES `Csomors` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Friends` (
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `FriendId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `ConnectionDate` datetime(6) NOT NULL DEFAULT NOW(),
    `RequestId` int NOT NULL,
    CONSTRAINT `PK_Friends` PRIMARY KEY (`UserId`, `FriendId`),
    CONSTRAINT `FK_Friends_AspNetUsers_FriendId` FOREIGN KEY (`FriendId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Friends_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Friends_FriendRequests_RequestId` FOREIGN KEY (`RequestId`) REFERENCES `FriendRequests` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `MovieComments` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `MovieId` int NOT NULL,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Creation` datetime(6) NOT NULL DEFAULT NOW(),
    `LastUpdate` datetime(6) NOT NULL DEFAULT NOW(),
    `Comment` varchar(500) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_MovieComments` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_MovieComments_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_MovieComments_Movies_MovieId` FOREIGN KEY (`MovieId`) REFERENCES `Movies` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `MovieMovieCategorySwitch` (
    `MovieId` int NOT NULL,
    `CategoryId` int NOT NULL,
    CONSTRAINT `PK_MovieMovieCategorySwitch` PRIMARY KEY (`MovieId`, `CategoryId`),
    CONSTRAINT `FK_MovieMovieCategorySwitch_MovieCategories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `MovieCategories` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_MovieMovieCategorySwitch_Movies_MovieId` FOREIGN KEY (`MovieId`) REFERENCES `Movies` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `UserMovieSwitch` (
    `MovieId` int NOT NULL,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `IsSeen` tinyint(1) NOT NULL DEFAULT FALSE,
    `IsAdded` tinyint(1) NOT NULL,
    `SeenOn` datetime(6) NULL,
    `AddedOn` datetime(6) NULL DEFAULT NOW(),
    `Rate` int NULL,
    CONSTRAINT `PK_UserMovieSwitch` PRIMARY KEY (`UserId`, `MovieId`),
    CONSTRAINT `FK_UserMovieSwitch_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_UserMovieSwitch_Movies_MovieId` FOREIGN KEY (`MovieId`) REFERENCES `Movies` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `PlanGroupChatMessages` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Message` longtext CHARACTER SET utf8mb4 NOT NULL,
    `SenderId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Sent` datetime(6) NOT NULL DEFAULT NOW(),
    `GroupId` int NOT NULL,
    CONSTRAINT `PK_PlanGroupChatMessages` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PlanGroupChatMessages_AspNetUsers_SenderId` FOREIGN KEY (`SenderId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_PlanGroupChatMessages_PlanGroups_GroupId` FOREIGN KEY (`GroupId`) REFERENCES `PlanGroups` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `PlanGroupIdeas` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Content` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `CreatorId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Creation` datetime(6) NOT NULL DEFAULT NOW(),
    `GroupId` int NOT NULL,
    CONSTRAINT `PK_PlanGroupIdeas` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PlanGroupIdeas_AspNetUsers_CreatorId` FOREIGN KEY (`CreatorId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_PlanGroupIdeas_PlanGroups_GroupId` FOREIGN KEY (`GroupId`) REFERENCES `PlanGroups` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `PlanGroupPlans` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `Description` varchar(512) CHARACTER SET utf8mb4 NULL,
    `OwnerId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Creation` datetime(6) NOT NULL DEFAULT NOW(),
    `LastUpdaterId` varchar(255) CHARACTER SET utf8mb4 NULL,
    `LastUpdate` datetime(6) NULL DEFAULT NOW(),
    `StartTime` datetime(6) NOT NULL,
    `EndTime` datetime(6) NULL,
    `PriorityLevel` int NULL,
    `IsPublic` tinyint(1) NOT NULL DEFAULT FALSE,
    `PlanTypeId` int NULL,
    `MarkedUserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `MarkTypeId` int NOT NULL,
    `GroupId` int NOT NULL,
    CONSTRAINT `PK_PlanGroupPlans` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PlanGroupPlans_AspNetUsers_LastUpdaterId` FOREIGN KEY (`LastUpdaterId`) REFERENCES `AspNetUsers` (`Id`),
    CONSTRAINT `FK_PlanGroupPlans_AspNetUsers_MarkedUserId` FOREIGN KEY (`MarkedUserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_PlanGroupPlans_AspNetUsers_OwnerId` FOREIGN KEY (`OwnerId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_PlanGroupPlans_MarkTypes_MarkTypeId` FOREIGN KEY (`MarkTypeId`) REFERENCES `MarkTypes` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_PlanGroupPlans_PlanGroups_GroupId` FOREIGN KEY (`GroupId`) REFERENCES `PlanGroups` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_PlanGroupPlans_PlanTypes_PlanTypeId` FOREIGN KEY (`PlanTypeId`) REFERENCES `PlanTypes` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `UserPlanGroupsSwitch` (
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `GroupId` int NOT NULL,
    `RoleId` int NOT NULL,
    `Connection` datetime(6) NOT NULL DEFAULT NOW(),
    `AddedById` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_UserPlanGroupsSwitch` PRIMARY KEY (`UserId`, `GroupId`),
    CONSTRAINT `FK_UserPlanGroupsSwitch_AspNetUsers_AddedById` FOREIGN KEY (`AddedById`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_UserPlanGroupsSwitch_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_UserPlanGroupsSwitch_GroupRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `GroupRoles` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_UserPlanGroupsSwitch_PlanGroups_GroupId` FOREIGN KEY (`GroupId`) REFERENCES `PlanGroups` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Seasons` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Number` int NOT NULL,
    `SeriesId` int NOT NULL,
    CONSTRAINT `PK_Seasons` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Seasons_Series_SeriesId` FOREIGN KEY (`SeriesId`) REFERENCES `Series` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `SeriesComments` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `SeriesId` int NOT NULL,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Creation` datetime(6) NOT NULL DEFAULT NOW(),
    `LastUpdate` datetime(6) NOT NULL DEFAULT NOW(),
    `Comment` varchar(500) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_SeriesComments` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_SeriesComments_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_SeriesComments_Series_SeriesId` FOREIGN KEY (`SeriesId`) REFERENCES `Series` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `SeriesSeriesCategoriesSwitch` (
    `SeriesId` int NOT NULL,
    `CategoryId` int NOT NULL,
    CONSTRAINT `PK_SeriesSeriesCategoriesSwitch` PRIMARY KEY (`SeriesId`, `CategoryId`),
    CONSTRAINT `FK_SeriesSeriesCategoriesSwitch_Series_SeriesId` FOREIGN KEY (`SeriesId`) REFERENCES `Series` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_SeriesSeriesCategoriesSwitch_SeriesCategories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `SeriesCategories` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `UserSeriesSwitch` (
    `SeriesId` int NOT NULL,
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `IsAdded` tinyint(1) NOT NULL,
    `AddedOn` datetime(6) NULL DEFAULT NOW(),
    `Rate` int NULL,
    CONSTRAINT `PK_UserSeriesSwitch` PRIMARY KEY (`UserId`, `SeriesId`),
    CONSTRAINT `FK_UserSeriesSwitch_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_UserSeriesSwitch_Series_SeriesId` FOREIGN KEY (`SeriesId`) REFERENCES `Series` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `WorkingFields` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    `Length` decimal(65,30) NOT NULL,
    `WorkingDayId` int NOT NULL,
    CONSTRAINT `PK_WorkingFields` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_WorkingFields_WorkingDays_WorkingDayId` FOREIGN KEY (`WorkingDayId`) REFERENCES `WorkingDays` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `CsomorPersonTables` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Date` datetime(6) NOT NULL,
    `PersonId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `IsAvailable` tinyint(1) NOT NULL DEFAULT FALSE,
    `WorkId` varchar(255) CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_CsomorPersonTables` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_CsomorPersonTables_CsomorPersons_PersonId` FOREIGN KEY (`PersonId`) REFERENCES `CsomorPersons` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_CsomorPersonTables_CsomorWorks_WorkId` FOREIGN KEY (`WorkId`) REFERENCES `CsomorWorks` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `CsomorWorkTables` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Date` datetime(6) NOT NULL,
    `WorkId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `IsActive` tinyint(1) NOT NULL DEFAULT FALSE,
    `PersonId` varchar(255) CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_CsomorWorkTables` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_CsomorWorkTables_CsomorPersons_PersonId` FOREIGN KEY (`PersonId`) REFERENCES `CsomorPersons` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_CsomorWorkTables_CsomorWorks_WorkId` FOREIGN KEY (`WorkId`) REFERENCES `CsomorWorks` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `IgnoredWorks` (
    `PersonId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `WorkId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_IgnoredWorks` PRIMARY KEY (`PersonId`, `WorkId`),
    CONSTRAINT `FK_IgnoredWorks_CsomorPersons_PersonId` FOREIGN KEY (`PersonId`) REFERENCES `CsomorPersons` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_IgnoredWorks_CsomorWorks_WorkId` FOREIGN KEY (`WorkId`) REFERENCES `CsomorWorks` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `PlanGroupPlanComments` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Comment` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
    `SenderId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Creation` datetime(6) NOT NULL DEFAULT NOW(),
    `PlanId` int NOT NULL,
    CONSTRAINT `PK_PlanGroupPlanComments` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_PlanGroupPlanComments_AspNetUsers_SenderId` FOREIGN KEY (`SenderId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_PlanGroupPlanComments_PlanGroupPlans_PlanId` FOREIGN KEY (`PlanId`) REFERENCES `PlanGroupPlans` (`Id`) ON DELETE RESTRICT
);

CREATE TABLE `Episodes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `Number` int NOT NULL,
    `Description` varchar(300) CHARACTER SET utf8mb4 NULL,
    `SeasonId` int NOT NULL,
    `LastUpdaterId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `LastUpdate` datetime(6) NOT NULL,
    `ImageTitle` longtext CHARACTER SET utf8mb4 NULL,
    `ImageData` longblob NULL,
    CONSTRAINT `PK_Episodes` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Episodes_AspNetUsers_LastUpdaterId` FOREIGN KEY (`LastUpdaterId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Episodes_Seasons_SeasonId` FOREIGN KEY (`SeasonId`) REFERENCES `Seasons` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `UserEpisodeSwitch` (
    `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `EpisodeId` int NOT NULL,
    `Seen` tinyint(1) NOT NULL DEFAULT FALSE,
    `SeenOn` datetime(6) NULL,
    CONSTRAINT `PK_UserEpisodeSwitch` PRIMARY KEY (`UserId`, `EpisodeId`),
    CONSTRAINT `FK_UserEpisodeSwitch_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_UserEpisodeSwitch_Episodes_EpisodeId` FOREIGN KEY (`EpisodeId`) REFERENCES `Episodes` (`Id`) ON DELETE CASCADE
);

INSERT INTO `AspNetRoles` (`Id`, `AccessLevel`, `ConcurrencyStamp`, `Discriminator`, `Name`, `NormalizedName`)
VALUES ('fa5deb78-59c2-4faa-83dc-6c3369eedf20', 4, 'c263e607-a09d-4193-ab44-848d6fff12b5', 'WebsiteRole', 'Root', 'ROOT');
INSERT INTO `AspNetRoles` (`Id`, `AccessLevel`, `ConcurrencyStamp`, `Discriminator`, `Name`, `NormalizedName`)
VALUES ('936e4ddc-5d3f-5466-af3a-3b4a4424d518', 3, 'f3f304a8-a42d-49b7-bf46-5befd5b167f1', 'WebsiteRole', 'Status Library Moderator', 'STATUS LIBRARY MODERATOR');
INSERT INTO `AspNetRoles` (`Id`, `AccessLevel`, `ConcurrencyStamp`, `Discriminator`, `Name`, `NormalizedName`)
VALUES ('936e4ddc-5d3f-4355-af3a-304a4fe4f518', 1, '7803eb8b-a947-4a6f-8542-76599a7cf89a', 'WebsiteRole', 'Status Library User', 'STATUS LIBRARY USER');
INSERT INTO `AspNetRoles` (`Id`, `AccessLevel`, `ConcurrencyStamp`, `Discriminator`, `Name`, `NormalizedName`)
VALUES ('936e42dc-5d3f-4355-bc3a-304a4fe4f518', 3, '7e4825cd-fe38-4f6c-b4ba-8a7d16a1eb4e', 'WebsiteRole', 'Administrator', 'ADMINISTRATOR');
INSERT INTO `AspNetRoles` (`Id`, `AccessLevel`, `ConcurrencyStamp`, `Discriminator`, `Name`, `NormalizedName`)
VALUES ('5e0a9192-793f-4c85-a0b1-3198295bf409', 2, 'e0886ef8-fbd2-4e26-91cb-98e606c24669', 'WebsiteRole', 'Moderator', 'MODERATOR');
INSERT INTO `AspNetRoles` (`Id`, `AccessLevel`, `ConcurrencyStamp`, `Discriminator`, `Name`, `NormalizedName`)
VALUES ('776474d7-8d01-4809-963e-c721f39dbb45', 1, '6427b27f-a984-493b-8440-d03ff98fdfd3', 'WebsiteRole', 'Normal', 'NORMAL');
INSERT INTO `AspNetRoles` (`Id`, `AccessLevel`, `ConcurrencyStamp`, `Discriminator`, `Name`, `NormalizedName`)
VALUES ('2f76c2fc-bbca-41ff-86ed-5ef43d41d8f9', 0, '36f016e1-6d49-4cd1-8869-c465e983aab7', 'WebsiteRole', 'Visitor', 'VISITOR');
INSERT INTO `AspNetRoles` (`Id`, `AccessLevel`, `ConcurrencyStamp`, `Discriminator`, `Name`, `NormalizedName`)
VALUES ('936d4dfc-5536-4d5f-af2a-304d4fe4f518', 3, '4a71b65a-7178-480b-93ff-aad89f800c02', 'WebsiteRole', 'Status Library Administrator', 'STATUS LIBRARY ADMINISTRATOR');

INSERT INTO `AspNetUsers` (`Id`, `AccessFailedCount`, `Allergy`, `BirthDay`, `City`, `ConcurrencyStamp`, `Country`, `Discriminator`, `Email`, `EmailConfirmed`, `FullName`, `GenderId`, `Group`, `IsActive`, `LockoutEnabled`, `LockoutEnd`, `NormalizedEmail`, `NormalizedUserName`, `PasswordHash`, `PhoneNumber`, `PhoneNumberConfirmed`, `ProfileImageData`, `ProfileImageTitle`, `SecondaryEmail`, `SecurityStamp`, `TShirtSize`, `TwoFactorEnabled`, `UserName`)
VALUES ('fa2edf69-5fc8-a163-9fc5-726f3b94e51b', 0, NULL, NULL, NULL, '12294760-47a6-46cd-aa27-24e3e9663b9a', NULL, 'User', 'barni.pbs@gmail.com', TRUE, 'Root', NULL, NULL, TRUE, FALSE, NULL, 'BARNI.PBS@GMAIL.COM', 'BARNI363HUN', 'AQAAAAEAACcQAAAAEL9QeDNFqEAq8WDl2/fXBSc02Tzxxnek963ILEw1L3aQsFysXXG4L3KvFYIVg/LpLA==', NULL, FALSE, NULL, NULL, NULL, '08423e1b-54ac-4385-85a0-e42ffdecfc54', NULL, FALSE, 'barni363hun');
INSERT INTO `AspNetUsers` (`Id`, `AccessFailedCount`, `Allergy`, `BirthDay`, `City`, `ConcurrencyStamp`, `Country`, `Discriminator`, `Email`, `EmailConfirmed`, `FullName`, `GenderId`, `Group`, `IsActive`, `LockoutEnabled`, `LockoutEnd`, `NormalizedEmail`, `NormalizedUserName`, `PasswordHash`, `PhoneNumber`, `PhoneNumberConfirmed`, `ProfileImageData`, `ProfileImageTitle`, `SecondaryEmail`, `SecurityStamp`, `TShirtSize`, `TwoFactorEnabled`, `UserName`)
VALUES ('cd5e5069-59c8-4163-95c5-776fab95e51a', 0, NULL, NULL, NULL, 'b752e32c-f81e-4679-b3f1-e3b2e047f119', NULL, 'User', 'root@karcags.hu', TRUE, 'Root', NULL, NULL, TRUE, FALSE, NULL, 'ROOT@KARCAGS.HU', 'ROOT', 'AQAAAAEAACcQAAAAEHdK+ODabrjejNLGhod4ftL37G5zT97p2g0Ck5dH9MchA2B/JFDiwb9kk9soZBPF5Q==', NULL, FALSE, NULL, NULL, NULL, '6bd9afe8-0d4b-4726-a549-30bf5bef47e8', NULL, FALSE, 'root');
INSERT INTO `AspNetUsers` (`Id`, `AccessFailedCount`, `Allergy`, `BirthDay`, `City`, `ConcurrencyStamp`, `Country`, `Discriminator`, `Email`, `EmailConfirmed`, `FullName`, `GenderId`, `Group`, `IsActive`, `LockoutEnabled`, `LockoutEnd`, `NormalizedEmail`, `NormalizedUserName`, `PasswordHash`, `PhoneNumber`, `PhoneNumberConfirmed`, `ProfileImageData`, `ProfileImageTitle`, `SecondaryEmail`, `SecurityStamp`, `TShirtSize`, `TwoFactorEnabled`, `UserName`)
VALUES ('f8237fac-c6dc-47b0-8f71-b72f93368b02', 0, NULL, NULL, NULL, '27c15edc-8ee3-4b53-9bc6-5b4fb9303624', NULL, 'User', 'aron.klenovszky@gmail.com', TRUE, 'Klenovszky Áron', NULL, NULL, TRUE, FALSE, NULL, 'ARON.KLENOVSZKY@GMAIL.COM', 'AARONKAA', 'AQAAAAEAACcQAAAAEL9QeDNFqEAq8WDl2/fXBSc02Tzxxnek963ILEw1L3aQsFysXXG4L3KvFYIVg/LpLA==', NULL, FALSE, NULL, NULL, NULL, 'a60878fe-c124-4039-b6db-61ef0a73f40c', NULL, FALSE, 'aaronkaa');
INSERT INTO `AspNetUsers` (`Id`, `AccessFailedCount`, `Allergy`, `BirthDay`, `City`, `ConcurrencyStamp`, `Country`, `Discriminator`, `Email`, `EmailConfirmed`, `FullName`, `GenderId`, `Group`, `IsActive`, `LockoutEnabled`, `LockoutEnd`, `NormalizedEmail`, `NormalizedUserName`, `PasswordHash`, `PhoneNumber`, `PhoneNumberConfirmed`, `ProfileImageData`, `ProfileImageTitle`, `SecondaryEmail`, `SecurityStamp`, `TShirtSize`, `TwoFactorEnabled`, `UserName`)
VALUES ('44045506-66fd-4af8-9d59-133c47d1787c', 0, NULL, NULL, NULL, 'aed1cc8b-bb0f-4611-84fb-66adda08a665', NULL, 'User', 'karcagtamas@outlook.com', TRUE, 'Karcag Tamas', NULL, NULL, TRUE, FALSE, NULL, 'KARCAGTAMAS@OUTLOOK.COM', 'KARCAGTAMAS', 'AQAAAAEAACcQAAAAEG9SljY4ow/I7990YZ15dSGvCesg0bad3pQSWi4ekt0RT8J5JuL3lQmNJCnxo2lGIA==', NULL, FALSE, NULL, NULL, NULL, '32ec8e40-c323-4d15-8ab3-37edcf2cbb69', NULL, FALSE, 'karcagtamas');

INSERT INTO `Genders` (`Id`, `Name`)
VALUES (1, 'Male');
INSERT INTO `Genders` (`Id`, `Name`)
VALUES (3, 'Other');
INSERT INTO `Genders` (`Id`, `Name`)
VALUES (2, 'Female');

INSERT INTO `GroupRoles` (`Id`, `AccessLevel`, `Title`)
VALUES (6, 5, 'Owner');
INSERT INTO `GroupRoles` (`Id`, `AccessLevel`, `Title`)
VALUES (1, 0, 'Visitor');
INSERT INTO `GroupRoles` (`Id`, `AccessLevel`, `Title`)
VALUES (5, 4, 'Administrator');
INSERT INTO `GroupRoles` (`Id`, `AccessLevel`, `Title`)
VALUES (3, 2, 'Editor');
INSERT INTO `GroupRoles` (`Id`, `AccessLevel`, `Title`)
VALUES (4, 3, 'Moderator');
INSERT INTO `GroupRoles` (`Id`, `AccessLevel`, `Title`)
VALUES (2, 1, 'Normal');

INSERT INTO `MarkTypes` (`Id`, `Title`)
VALUES (3, 'Modifier');
INSERT INTO `MarkTypes` (`Id`, `Title`)
VALUES (2, 'Owner');
INSERT INTO `MarkTypes` (`Id`, `Title`)
VALUES (1, 'Responsible');
INSERT INTO `MarkTypes` (`Id`, `Title`)
VALUES (4, 'Leader');

INSERT INTO `MovieCategories` (`Id`, `Name`)
VALUES (1, 'Drama');
INSERT INTO `MovieCategories` (`Id`, `Name`)
VALUES (2, 'Action');
INSERT INTO `MovieCategories` (`Id`, `Name`)
VALUES (3, 'Romantic');
INSERT INTO `MovieCategories` (`Id`, `Name`)
VALUES (4, 'Sci-fi');

INSERT INTO `NotificationSystems` (`Id`, `Name`, `ShortName`)
VALUES (1, 'System', 'Sys');
INSERT INTO `NotificationSystems` (`Id`, `Name`, `ShortName`)
VALUES (2, 'Event Manager', 'EM');
INSERT INTO `NotificationSystems` (`Id`, `Name`, `ShortName`)
VALUES (3, 'Plan Manager', 'PM');
INSERT INTO `NotificationSystems` (`Id`, `Name`, `ShortName`)
VALUES (4, 'Status Library', 'SL');
INSERT INTO `NotificationSystems` (`Id`, `Name`, `ShortName`)
VALUES (5, 'Work Manager', 'WM');

INSERT INTO `PlanTypes` (`Id`, `Name`)
VALUES (6, 'Event');
INSERT INTO `PlanTypes` (`Id`, `Name`)
VALUES (5, 'Decision');
INSERT INTO `PlanTypes` (`Id`, `Name`)
VALUES (4, 'Learning');
INSERT INTO `PlanTypes` (`Id`, `Name`)
VALUES (3, 'Nice To Have');
INSERT INTO `PlanTypes` (`Id`, `Name`)
VALUES (2, 'Future Idea');
INSERT INTO `PlanTypes` (`Id`, `Name`)
VALUES (1, 'Plan');

INSERT INTO `SeriesCategories` (`Id`, `Name`)
VALUES (2, 'Action');
INSERT INTO `SeriesCategories` (`Id`, `Name`)
VALUES (1, 'Drama');
INSERT INTO `SeriesCategories` (`Id`, `Name`)
VALUES (4, 'Sci-fi');
INSERT INTO `SeriesCategories` (`Id`, `Name`)
VALUES (3, 'Romantic');

INSERT INTO `WorkingDayTypes` (`Id`, `DayIsActive`, `Title`)
VALUES (1, TRUE, 'Work Day');

INSERT INTO `WorkingDayTypes` (`Id`, `Title`)
VALUES (2, 'University');
INSERT INTO `WorkingDayTypes` (`Id`, `Title`)
VALUES (3, 'Empty Day');
INSERT INTO `WorkingDayTypes` (`Id`, `Title`)
VALUES (4, 'Holiday');

INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (1, 2, 1, 'Login');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (82, 1, 4, 'Season Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (81, 1, 4, 'Season Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (80, 1, 4, 'My Series List Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (79, 1, 4, 'Series Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (78, 1, 4, 'Series Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (77, 1, 4, 'Series Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (76, 1, 4, 'My Movie List Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (75, 1, 4, 'Movie Seen Status Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (74, 1, 4, 'My Book List Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (73, 1, 4, 'Book Read Status Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (72, 1, 4, 'Book Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (71, 1, 4, 'Book Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (70, 1, 4, 'Book Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (69, 1, 4, 'Movie Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (68, 1, 4, 'Movie Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (67, 1, 4, 'Movie Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (38, 3, 2, 'Event PayOut Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (37, 3, 2, 'Event PayOut Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (36, 3, 2, 'Event PayOut Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (35, 1, 2, 'Event ToDo Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (34, 2, 2, 'Event ToDo Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (83, 1, 4, 'Season Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (84, 1, 4, 'Episode Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (85, 1, 4, 'Episode Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (86, 1, 4, 'Episode Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (58, 2, 5, 'Working Day Type Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (57, 1, 5, 'Working Day Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (56, 1, 5, 'Working Day Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (55, 1, 5, 'Working Day Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (54, 1, 5, 'Working Field Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (53, 1, 5, 'Working Field Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (52, 1, 5, 'Working Field Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (101, 1, 4, 'Series Comment Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (100, 2, 4, 'Series Comment Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (99, 2, 4, 'Series Comment Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (33, 2, 2, 'Event ToDo Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (98, 2, 4, 'Series Category Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (96, 2, 4, 'Series Category Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (95, 1, 4, 'Movie Comment Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (94, 2, 4, 'Movie Comment Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (93, 2, 4, 'Movie Comment Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (92, 2, 4, 'Movie Category Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (91, 2, 4, 'Movie Category Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (90, 2, 4, 'Movie Category Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (89, 1, 4, 'Season Seen Status Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (88, 1, 4, 'Series Seen Status Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (87, 1, 4, 'Episode Seen Status Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (97, 2, 4, 'Series Category Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (59, 3, 5, 'Working Day Type Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (32, 2, 2, 'Role Removed In An Event');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (30, 2, 2, 'Role Added In An Event');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (61, 1, 1, 'Message Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (51, 3, 1, 'News Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (50, 1, 1, 'News Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (49, 2, 1, 'News Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (48, 3, 1, 'Friend Removed');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (47, 2, 1, 'You Has a new Friend');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (46, 2, 1, 'Friend Request Declined');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (45, 2, 1, 'Friend Request Accepted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (44, 1, 1, 'Friend Request Sent');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (43, 2, 1, 'Friend Request Received');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (42, 3, 1, 'Profile Disabled');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (41, 2, 1, 'Username Changed');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (40, 1, 1, 'Profile Image Changed');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (39, 3, 1, 'Password Changed');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (8, 1, 1, 'ToDo Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (7, 2, 1, 'ToDo Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (6, 2, 1, 'ToDo Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (5, 1, 1, 'Message Arrived');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (4, 3, 1, 'My Profile Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (3, 1, 1, 'Logout');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (2, 3, 1, 'Registration');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (62, 1, 1, 'Message Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (63, 1, 1, 'Message Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (64, 2, 1, 'Gender Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (65, 3, 1, 'Gender Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (29, 2, 2, 'Event Role Added To A User');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (28, 3, 2, 'Event Role Deleted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (27, 2, 2, 'Event Role Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (26, 2, 2, 'Event Role Added');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (25, 1, 2, 'Event Date Changed');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (24, 2, 2, 'Event Evolved To GT Event');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (23, 2, 2, 'Event Evolved To Sport Event');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (22, 3, 2, 'Removed From An Event');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (21, 3, 2, 'Event Member Removed');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (20, 1, 2, 'Decline Event Invitation');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (31, 2, 2, 'Event Role Removed From A User');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (19, 1, 2, 'Accept Event Invitation');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (17, 2, 2, 'Invitation Declined');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (16, 2, 2, 'Invitation Accepted');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (15, 2, 2, 'Event Member Invited');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (14, 1, 2, 'Event Message Arrived');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (13, 2, 2, 'Event Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (12, 1, 2, 'Event Locked');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (11, 2, 2, 'Event Published');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (10, 3, 2, 'Event Disabled');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (9, 3, 2, 'Event Created');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (66, 2, 1, 'Gender Updated');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (18, 1, 2, 'Invited To An Event');
INSERT INTO `NotificationTypes` (`Id`, `ImportanceLevel`, `SystemId`, `Title`)
VALUES (60, 2, 5, 'Working Day Type Updated');

CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);

CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);

CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);

CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);

CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);

CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);

CREATE INDEX `IX_AspNetUsers_GenderId` ON `AspNetUsers` (`GenderId`);

CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);

CREATE INDEX `IX_Books_CreatorId` ON `Books` (`CreatorId`);

CREATE INDEX `IX_Books_LastUpdaterId` ON `Books` (`LastUpdaterId`);

CREATE INDEX `IX_CsomorPersons_CsomorId` ON `CsomorPersons` (`CsomorId`);

CREATE INDEX `IX_CsomorPersonTables_PersonId` ON `CsomorPersonTables` (`PersonId`);

CREATE INDEX `IX_CsomorPersonTables_WorkId` ON `CsomorPersonTables` (`WorkId`);

CREATE INDEX `IX_Csomors_LastUpdaterId` ON `Csomors` (`LastUpdaterId`);

CREATE INDEX `IX_Csomors_OwnerId` ON `Csomors` (`OwnerId`);

CREATE INDEX `IX_CsomorWorks_CsomorId` ON `CsomorWorks` (`CsomorId`);

CREATE INDEX `IX_CsomorWorkTables_PersonId` ON `CsomorWorkTables` (`PersonId`);

CREATE INDEX `IX_CsomorWorkTables_WorkId` ON `CsomorWorkTables` (`WorkId`);

CREATE INDEX `IX_Episodes_LastUpdaterId` ON `Episodes` (`LastUpdaterId`);

CREATE INDEX `IX_Episodes_SeasonId` ON `Episodes` (`SeasonId`);

CREATE INDEX `IX_FriendRequests_DestinationId` ON `FriendRequests` (`DestinationId`);

CREATE INDEX `IX_FriendRequests_SenderId` ON `FriendRequests` (`SenderId`);

CREATE INDEX `IX_Friends_FriendId` ON `Friends` (`FriendId`);

CREATE INDEX `IX_Friends_RequestId` ON `Friends` (`RequestId`);

CREATE INDEX `IX_IgnoredWorks_WorkId` ON `IgnoredWorks` (`WorkId`);

CREATE INDEX `IX_Messages_ReceiverId` ON `Messages` (`ReceiverId`);

CREATE INDEX `IX_Messages_SenderId` ON `Messages` (`SenderId`);

CREATE INDEX `IX_MovieComments_MovieId` ON `MovieComments` (`MovieId`);

CREATE INDEX `IX_MovieComments_UserId` ON `MovieComments` (`UserId`);

CREATE INDEX `IX_MovieMovieCategorySwitch_CategoryId` ON `MovieMovieCategorySwitch` (`CategoryId`);

CREATE INDEX `IX_Movies_CreatorId` ON `Movies` (`CreatorId`);

CREATE INDEX `IX_Movies_LastUpdaterId` ON `Movies` (`LastUpdaterId`);

CREATE INDEX `IX_News_CreatorId` ON `News` (`CreatorId`);

CREATE INDEX `IX_News_LastUpdaterId` ON `News` (`LastUpdaterId`);

CREATE INDEX `IX_Notifications_OwnerId` ON `Notifications` (`OwnerId`);

CREATE INDEX `IX_Notifications_TypeId` ON `Notifications` (`TypeId`);

CREATE INDEX `IX_NotificationTypes_SystemId` ON `NotificationTypes` (`SystemId`);

CREATE INDEX `IX_PlanGroupChatMessages_GroupId` ON `PlanGroupChatMessages` (`GroupId`);

CREATE INDEX `IX_PlanGroupChatMessages_SenderId` ON `PlanGroupChatMessages` (`SenderId`);

CREATE INDEX `IX_PlanGroupIdeas_CreatorId` ON `PlanGroupIdeas` (`CreatorId`);

CREATE INDEX `IX_PlanGroupIdeas_GroupId` ON `PlanGroupIdeas` (`GroupId`);

CREATE INDEX `IX_PlanGroupPlanComments_PlanId` ON `PlanGroupPlanComments` (`PlanId`);

CREATE INDEX `IX_PlanGroupPlanComments_SenderId` ON `PlanGroupPlanComments` (`SenderId`);

CREATE INDEX `IX_PlanGroupPlans_GroupId` ON `PlanGroupPlans` (`GroupId`);

CREATE INDEX `IX_PlanGroupPlans_LastUpdaterId` ON `PlanGroupPlans` (`LastUpdaterId`);

CREATE INDEX `IX_PlanGroupPlans_MarkedUserId` ON `PlanGroupPlans` (`MarkedUserId`);

CREATE INDEX `IX_PlanGroupPlans_MarkTypeId` ON `PlanGroupPlans` (`MarkTypeId`);

CREATE INDEX `IX_PlanGroupPlans_OwnerId` ON `PlanGroupPlans` (`OwnerId`);

CREATE INDEX `IX_PlanGroupPlans_PlanTypeId` ON `PlanGroupPlans` (`PlanTypeId`);

CREATE INDEX `IX_PlanGroups_CreatorId` ON `PlanGroups` (`CreatorId`);

CREATE INDEX `IX_PlanGroups_LastUpdaterId` ON `PlanGroups` (`LastUpdaterId`);

CREATE INDEX `IX_Plans_OwnerId` ON `Plans` (`OwnerId`);

CREATE INDEX `IX_Plans_PlanTypeId` ON `Plans` (`PlanTypeId`);

CREATE INDEX `IX_Seasons_SeriesId` ON `Seasons` (`SeriesId`);

CREATE INDEX `IX_Series_CreatorId` ON `Series` (`CreatorId`);

CREATE INDEX `IX_Series_LastUpdaterId` ON `Series` (`LastUpdaterId`);

CREATE INDEX `IX_SeriesComments_SeriesId` ON `SeriesComments` (`SeriesId`);

CREATE INDEX `IX_SeriesComments_UserId` ON `SeriesComments` (`UserId`);

CREATE INDEX `IX_SeriesSeriesCategoriesSwitch_CategoryId` ON `SeriesSeriesCategoriesSwitch` (`CategoryId`);

CREATE INDEX `IX_SharedCsomors_CsomorId` ON `SharedCsomors` (`CsomorId`);

CREATE INDEX `IX_Tasks_OwnerId` ON `Tasks` (`OwnerId`);

CREATE INDEX `IX_UserBookSwitch_BookId` ON `UserBookSwitch` (`BookId`);

CREATE INDEX `IX_UserEpisodeSwitch_EpisodeId` ON `UserEpisodeSwitch` (`EpisodeId`);

CREATE INDEX `IX_UserMovieSwitch_MovieId` ON `UserMovieSwitch` (`MovieId`);

CREATE INDEX `IX_UserPlanGroupsSwitch_AddedById` ON `UserPlanGroupsSwitch` (`AddedById`);

CREATE INDEX `IX_UserPlanGroupsSwitch_GroupId` ON `UserPlanGroupsSwitch` (`GroupId`);

CREATE INDEX `IX_UserPlanGroupsSwitch_RoleId` ON `UserPlanGroupsSwitch` (`RoleId`);

CREATE INDEX `IX_UserSeriesSwitch_SeriesId` ON `UserSeriesSwitch` (`SeriesId`);

CREATE INDEX `IX_WorkingDays_TypeId` ON `WorkingDays` (`TypeId`);

CREATE INDEX `IX_WorkingDays_UserId` ON `WorkingDays` (`UserId`);

CREATE INDEX `IX_WorkingFields_WorkingDayId` ON `WorkingFields` (`WorkingDayId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210412201613_Init', '5.0.5');

COMMIT;
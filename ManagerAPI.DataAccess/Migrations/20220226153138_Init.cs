using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagerAPI.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccessLevel = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovieCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NotificationSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationSystems", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SeriesCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesCategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkingDayTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DayIsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingDayTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "NOW()"),
                    LastLogin = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "NOW()"),
                    SecondaryEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TShirtSize = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Allergy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Group = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDay = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProfileImageTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfileImageData = table.Column<byte[]>(type: "longblob", nullable: true),
                    Country = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImportanceLevel = table.Column<int>(type: "int", nullable: false),
                    SystemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationTypes_NotificationSystems_SystemId",
                        column: x => x.SystemId,
                        principalTable: "NotificationSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Author = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Publish = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatorId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastUpdaterId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_AspNetUsers_LastUpdaterId",
                        column: x => x.LastUpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Csomors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    OwnerId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "NOW()"),
                    LastUpdaterId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Finish = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MaxWorkHour = table.Column<int>(type: "int", nullable: false),
                    MinRestHour = table.Column<int>(type: "int", nullable: false),
                    IsShared = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    IsPublic = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    HasGeneratedCsomor = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    LastGeneration = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Csomors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Csomors_AspNetUsers_LastUpdaterId",
                        column: x => x.LastUpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Csomors_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SenderId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DestinationId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    Message = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Response = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ResponseDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendRequests_AspNetUsers_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendRequests_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    SenderId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReceiverId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(999)", maxLength: 999, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReleaseYear = table.Column<int>(type: "int", nullable: true),
                    Length = table.Column<int>(type: "int", nullable: true),
                    Director = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrailerUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageTitle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageData = table.Column<byte[]>(type: "longblob", nullable: false),
                    CreatorId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastUpdaterId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_AspNetUsers_LastUpdaterId",
                        column: x => x.LastUpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatorId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    LastUpdaterId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_News_AspNetUsers_LastUpdaterId",
                        column: x => x.LastUpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(999)", maxLength: 999, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartYear = table.Column<int>(type: "int", nullable: true),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    TrailerUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageTitle = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageData = table.Column<byte[]>(type: "longblob", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    CreatorId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastUpdaterId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Series_AspNetUsers_LastUpdaterId",
                        column: x => x.LastUpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsSolved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OwnerId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkingDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingDays_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkingDays_WorkingDayTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "WorkingDayTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    OwnerId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsRead = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    Archived = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "NotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserBookSwitch",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Read = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    ReadOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AddOn = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookSwitch", x => new { x.UserId, x.BookId });
                    table.ForeignKey(
                        name: "FK_UserBookSwitch_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBookSwitch_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CsomorPersons",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CsomorId = table.Column<int>(type: "int", nullable: false),
                    PlusWorkCounter = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsIgnored = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsomorPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CsomorPersons_Csomors_CsomorId",
                        column: x => x.CsomorId,
                        principalTable: "Csomors",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CsomorWorks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CsomorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsomorWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CsomorWorks_Csomors_CsomorId",
                        column: x => x.CsomorId,
                        principalTable: "Csomors",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SharedCsomors",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CsomorId = table.Column<int>(type: "int", nullable: false),
                    SharedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    HasWriteAccess = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedCsomors", x => new { x.UserId, x.CsomorId });
                    table.ForeignKey(
                        name: "FK_SharedCsomors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SharedCsomors_Csomors_CsomorId",
                        column: x => x.CsomorId,
                        principalTable: "Csomors",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FriendId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConnectionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.UserId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_FriendId",
                        column: x => x.FriendId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friends_FriendRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "FriendRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovieComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    Comment = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieComments_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MovieMovieCategorySwitch",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMovieCategorySwitch", x => new { x.MovieId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_MovieMovieCategorySwitch_MovieCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "MovieCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieMovieCategorySwitch_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserMovieSwitch",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsSeen = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    IsAdded = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SeenOn = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "NOW()"),
                    Rate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovieSwitch", x => new { x.UserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_UserMovieSwitch_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserMovieSwitch_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(type: "int", nullable: false),
                    SeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SeriesComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SeriesId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "NOW()"),
                    Comment = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeriesComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeriesComments_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SeriesSeriesCategoriesSwitch",
                columns: table => new
                {
                    SeriesId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesSeriesCategoriesSwitch", x => new { x.SeriesId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_SeriesSeriesCategoriesSwitch_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesSeriesCategoriesSwitch_SeriesCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SeriesCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserSeriesSwitch",
                columns: table => new
                {
                    SeriesId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAdded = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "NOW()"),
                    Rate = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSeriesSwitch", x => new { x.UserId, x.SeriesId });
                    table.ForeignKey(
                        name: "FK_UserSeriesSwitch_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSeriesSwitch_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkingFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Length = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    WorkingDayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingFields_WorkingDays_WorkingDayId",
                        column: x => x.WorkingDayId,
                        principalTable: "WorkingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CsomorPersonTables",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PersonId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    WorkId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsomorPersonTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CsomorPersonTables_CsomorPersons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "CsomorPersons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CsomorPersonTables_CsomorWorks_WorkId",
                        column: x => x.WorkId,
                        principalTable: "CsomorWorks",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CsomorWorkTables",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WorkId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    PersonId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CsomorWorkTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CsomorWorkTables_CsomorPersons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "CsomorPersons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CsomorWorkTables_CsomorWorks_WorkId",
                        column: x => x.WorkId,
                        principalTable: "CsomorWorks",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IgnoredWorks",
                columns: table => new
                {
                    PersonId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IgnoredWorks", x => new { x.PersonId, x.WorkId });
                    table.ForeignKey(
                        name: "FK_IgnoredWorks_CsomorPersons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "CsomorPersons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IgnoredWorks_CsomorWorks_WorkId",
                        column: x => x.WorkId,
                        principalTable: "CsomorWorks",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    LastUpdaterId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ImageTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageData = table.Column<byte[]>(type: "longblob", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episodes_AspNetUsers_LastUpdaterId",
                        column: x => x.LastUpdaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Episodes_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserEpisodeSwitch",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EpisodeId = table.Column<int>(type: "int", nullable: false),
                    Seen = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    SeenOn = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEpisodeSwitch", x => new { x.UserId, x.EpisodeId });
                    table.ForeignKey(
                        name: "FK_UserEpisodeSwitch_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserEpisodeSwitch_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "AccessLevel", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f76c2fc-bbca-41ff-86ed-5ef43d41d8f9", 0, "63868519-e55d-480e-b291-c681bfdb95f0", "WebsiteRole", "Visitor", "VISITOR" },
                    { "5e0a9192-793f-4c85-a0b1-3198295bf409", 2, "83b020fb-c887-4d2d-b673-eb3989c76494", "WebsiteRole", "Moderator", "MODERATOR" },
                    { "776474d7-8d01-4809-963e-c721f39dbb45", 1, "acdc1508-d372-4765-8d83-593d6b53d1c0", "WebsiteRole", "Normal", "NORMAL" },
                    { "936d4dfc-5536-4d5f-af2a-304d4fe4f518", 3, "1f25781a-1620-4cb2-aa41-1f48344c8358", "WebsiteRole", "Status Library Administrator", "STATUS LIBRARY ADMINISTRATOR" },
                    { "936e42dc-5d3f-4355-bc3a-304a4fe4f518", 3, "830bd94e-6014-442b-a4e6-cb018c2f374e", "WebsiteRole", "Administrator", "ADMINISTRATOR" },
                    { "936e4ddc-5d3f-4355-af3a-304a4fe4f518", 1, "bd6f4de5-29ad-42b3-8f6b-9b9cc01cd1ce", "WebsiteRole", "Status Library User", "STATUS LIBRARY USER" },
                    { "936e4ddc-5d3f-5466-af3a-3b4a4424d518", 3, "b3f06b57-7dba-4edb-8ba9-e4369f32eb11", "WebsiteRole", "Status Library Moderator", "STATUS LIBRARY MODERATOR" },
                    { "fa5deb78-59c2-4faa-83dc-6c3369eedf20", 4, "7404ea79-d1b4-465f-8ed5-dacfed36e2d3", "WebsiteRole", "Root", "ROOT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Allergy", "BirthDay", "City", "ConcurrencyStamp", "Country", "Discriminator", "Email", "EmailConfirmed", "FullName", "GenderId", "Group", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageData", "ProfileImageTitle", "SecondaryEmail", "SecurityStamp", "TShirtSize", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cd5e5069-59c8-4163-95c5-776fab95e51a", 0, "", null, "", "8707df4b-1c0e-4b65-84e0-a4996c4fa221", "", "User", "root@karcags.hu", true, "Root", null, "", true, false, null, "ROOT@KARCAGS.HU", "ROOT", "AQAAAAEAACcQAAAAEHdK+ODabrjejNLGhod4ftL37G5zT97p2g0Ck5dH9MchA2B/JFDiwb9kk9soZBPF5Q==", null, false, null, "", "", "f89f79b1-1cf1-43df-87a0-642dcee56552", "", false, "root" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "MovieCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Drama" },
                    { 2, "Action" },
                    { 3, "Romantic" },
                    { 4, "Sci-fi" }
                });

            migrationBuilder.InsertData(
                table: "NotificationSystems",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "System", "Sys" },
                    { 2, "Event Manager", "EM" },
                    { 3, "Plan Manager", "PM" },
                    { 4, "Status Library", "SL" },
                    { 5, "Work Manager", "WM" }
                });

            migrationBuilder.InsertData(
                table: "SeriesCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Drama" },
                    { 2, "Action" },
                    { 3, "Romantic" },
                    { 4, "Sci-fi" }
                });

            migrationBuilder.InsertData(
                table: "WorkingDayTypes",
                columns: new[] { "Id", "DayIsActive", "Title" },
                values: new object[] { 1, true, "Work Day" });

            migrationBuilder.InsertData(
                table: "WorkingDayTypes",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 2, "University" },
                    { 3, "Empty Day" },
                    { 4, "Holiday" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Allergy", "BirthDay", "City", "ConcurrencyStamp", "Country", "Discriminator", "Email", "EmailConfirmed", "FullName", "GenderId", "Group", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageData", "ProfileImageTitle", "SecondaryEmail", "SecurityStamp", "TShirtSize", "TwoFactorEnabled", "UserName" },
                values: new object[] { "44045506-66fd-4af8-9d59-133c47d1787c", 0, "", null, "", "7cf836a7-842c-41fe-902a-5e9f86fc5260", "", "User", "karcagtamas@outlook.com", true, "Karcag Tamas", 1, "", true, false, null, "KARCAGTAMAS@OUTLOOK.COM", "KARCAGTAMAS", "AQAAAAEAACcQAAAAEG9SljY4ow/I7990YZ15dSGvCesg0bad3pQSWi4ekt0RT8J5JuL3lQmNJCnxo2lGIA==", null, false, null, "", "", "142b7322-39d8-4cb3-8816-582511857fa5", "", false, "karcagtamas" });

            migrationBuilder.InsertData(
                table: "NotificationTypes",
                columns: new[] { "Id", "ImportanceLevel", "SystemId", "Title" },
                values: new object[,]
                {
                    { 1, 2, 1, "Login" },
                    { 2, 3, 1, "Registration" },
                    { 3, 1, 1, "Logout" },
                    { 4, 3, 1, "My Profile Updated" },
                    { 5, 1, 1, "Message Arrived" },
                    { 6, 2, 1, "ToDo Added" },
                    { 7, 2, 1, "ToDo Deleted" },
                    { 8, 1, 1, "ToDo Updated" },
                    { 9, 3, 2, "Event Created" },
                    { 10, 3, 2, "Event Disabled" },
                    { 11, 2, 2, "Event Published" },
                    { 12, 1, 2, "Event Locked" },
                    { 13, 2, 2, "Event Updated" },
                    { 14, 1, 2, "Event Message Arrived" },
                    { 15, 2, 2, "Event Member Invited" },
                    { 16, 2, 2, "Invitation Accepted" },
                    { 17, 2, 2, "Invitation Declined" },
                    { 18, 1, 2, "Invited To An Event" },
                    { 19, 1, 2, "Accept Event Invitation" },
                    { 20, 1, 2, "Decline Event Invitation" },
                    { 21, 3, 2, "Event Member Removed" },
                    { 22, 3, 2, "Removed From An Event" },
                    { 23, 2, 2, "Event Evolved To Sport Event" },
                    { 24, 2, 2, "Event Evolved To GT Event" },
                    { 25, 1, 2, "Event Date Changed" },
                    { 26, 2, 2, "Event Role Added" },
                    { 27, 2, 2, "Event Role Updated" },
                    { 28, 3, 2, "Event Role Deleted" },
                    { 29, 2, 2, "Event Role Added To A User" },
                    { 30, 2, 2, "Role Added In An Event" },
                    { 31, 2, 2, "Event Role Removed From A User" },
                    { 32, 2, 2, "Role Removed In An Event" },
                    { 33, 2, 2, "Event ToDo Added" },
                    { 34, 2, 2, "Event ToDo Deleted" },
                    { 35, 1, 2, "Event ToDo Updated" },
                    { 36, 3, 2, "Event PayOut Added" },
                    { 37, 3, 2, "Event PayOut Deleted" },
                    { 38, 3, 2, "Event PayOut Updated" },
                    { 39, 3, 1, "Password Changed" },
                    { 40, 1, 1, "Profile Image Changed" },
                    { 41, 2, 1, "Username Changed" },
                    { 42, 3, 1, "Profile Disabled" },
                    { 43, 2, 1, "Friend Request Received" },
                    { 44, 1, 1, "Friend Request Sent" },
                    { 45, 2, 1, "Friend Request Accepted" },
                    { 46, 2, 1, "Friend Request Declined" },
                    { 47, 2, 1, "You Has a new Friend" },
                    { 48, 3, 1, "Friend Removed" },
                    { 49, 2, 1, "News Added" },
                    { 50, 1, 1, "News Updated" },
                    { 51, 3, 1, "News Deleted" },
                    { 52, 1, 5, "Working Field Added" },
                    { 53, 1, 5, "Working Field Deleted" },
                    { 54, 1, 5, "Working Field Updated" },
                    { 55, 1, 5, "Working Day Added" },
                    { 56, 1, 5, "Working Day Deleted" },
                    { 57, 1, 5, "Working Day Updated" },
                    { 58, 2, 5, "Working Day Type Added" },
                    { 59, 3, 5, "Working Day Type Deleted" },
                    { 60, 2, 5, "Working Day Type Updated" },
                    { 61, 1, 1, "Message Added" },
                    { 62, 1, 1, "Message Deleted" },
                    { 63, 1, 1, "Message Updated" },
                    { 64, 2, 1, "Gender Added" },
                    { 65, 3, 1, "Gender Deleted" },
                    { 66, 2, 1, "Gender Updated" },
                    { 67, 1, 4, "Movie Added" },
                    { 68, 1, 4, "Movie Deleted" },
                    { 69, 1, 4, "Movie Updated" },
                    { 70, 1, 4, "Book Added" },
                    { 71, 1, 4, "Book Deleted" },
                    { 72, 1, 4, "Book Updated" },
                    { 73, 1, 4, "Book Read Status Updated" },
                    { 74, 1, 4, "My Book List Updated" },
                    { 75, 1, 4, "Movie Seen Status Updated" },
                    { 76, 1, 4, "My Movie List Updated" },
                    { 77, 1, 4, "Series Added" },
                    { 78, 1, 4, "Series Deleted" },
                    { 79, 1, 4, "Series Updated" },
                    { 80, 1, 4, "My Series List Updated" },
                    { 81, 1, 4, "Season Added" },
                    { 82, 1, 4, "Season Deleted" },
                    { 83, 1, 4, "Season Updated" },
                    { 84, 1, 4, "Episode Added" },
                    { 85, 1, 4, "Episode Deleted" },
                    { 86, 1, 4, "Episode Updated" },
                    { 87, 1, 4, "Episode Seen Status Updated" },
                    { 88, 1, 4, "Series Seen Status Updated" },
                    { 89, 1, 4, "Season Seen Status Updated" },
                    { 90, 2, 4, "Movie Category Added" },
                    { 91, 2, 4, "Movie Category Deleted" },
                    { 92, 2, 4, "Movie Category Updated" },
                    { 93, 2, 4, "Movie Comment Added" },
                    { 94, 2, 4, "Movie Comment Deleted" },
                    { 95, 1, 4, "Movie Comment Updated" },
                    { 96, 2, 4, "Series Category Added" },
                    { 97, 2, 4, "Series Category Deleted" },
                    { 98, 2, 4, "Series Category Updated" },
                    { 99, 2, 4, "Series Comment Added" },
                    { 100, 2, 4, "Series Comment Deleted" },
                    { 101, 1, 4, "Series Comment Updated" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CreatorId",
                table: "Books",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LastUpdaterId",
                table: "Books",
                column: "LastUpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_CsomorPersons_CsomorId",
                table: "CsomorPersons",
                column: "CsomorId");

            migrationBuilder.CreateIndex(
                name: "IX_CsomorPersonTables_PersonId",
                table: "CsomorPersonTables",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CsomorPersonTables_WorkId",
                table: "CsomorPersonTables",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Csomors_LastUpdaterId",
                table: "Csomors",
                column: "LastUpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Csomors_OwnerId",
                table: "Csomors",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CsomorWorks_CsomorId",
                table: "CsomorWorks",
                column: "CsomorId");

            migrationBuilder.CreateIndex(
                name: "IX_CsomorWorkTables_PersonId",
                table: "CsomorWorkTables",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CsomorWorkTables_WorkId",
                table: "CsomorWorkTables",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_LastUpdaterId",
                table: "Episodes",
                column: "LastUpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_DestinationId",
                table: "FriendRequests",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_SenderId",
                table: "FriendRequests",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_FriendId",
                table: "Friends",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_RequestId",
                table: "Friends",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_IgnoredWorks_WorkId",
                table: "IgnoredWorks",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieComments_MovieId",
                table: "MovieComments",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieComments_UserId",
                table: "MovieComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieMovieCategorySwitch_CategoryId",
                table: "MovieMovieCategorySwitch",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CreatorId",
                table: "Movies",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_LastUpdaterId",
                table: "Movies",
                column: "LastUpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_News_CreatorId",
                table: "News",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_News_LastUpdaterId",
                table: "News",
                column: "LastUpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_OwnerId",
                table: "Notifications",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TypeId",
                table: "Notifications",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTypes_SystemId",
                table: "NotificationTypes",
                column: "SystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SeriesId",
                table: "Seasons",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_CreatorId",
                table: "Series",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_LastUpdaterId",
                table: "Series",
                column: "LastUpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesComments_SeriesId",
                table: "SeriesComments",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesComments_UserId",
                table: "SeriesComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesSeriesCategoriesSwitch_CategoryId",
                table: "SeriesSeriesCategoriesSwitch",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedCsomors_CsomorId",
                table: "SharedCsomors",
                column: "CsomorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookSwitch_BookId",
                table: "UserBookSwitch",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEpisodeSwitch_EpisodeId",
                table: "UserEpisodeSwitch",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieSwitch_MovieId",
                table: "UserMovieSwitch",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSeriesSwitch_SeriesId",
                table: "UserSeriesSwitch",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDays_TypeId",
                table: "WorkingDays",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDays_UserId",
                table: "WorkingDays",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingFields_WorkingDayId",
                table: "WorkingFields",
                column: "WorkingDayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CsomorPersonTables");

            migrationBuilder.DropTable(
                name: "CsomorWorkTables");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "IgnoredWorks");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "MovieComments");

            migrationBuilder.DropTable(
                name: "MovieMovieCategorySwitch");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "SeriesComments");

            migrationBuilder.DropTable(
                name: "SeriesSeriesCategoriesSwitch");

            migrationBuilder.DropTable(
                name: "SharedCsomors");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "UserBookSwitch");

            migrationBuilder.DropTable(
                name: "UserEpisodeSwitch");

            migrationBuilder.DropTable(
                name: "UserMovieSwitch");

            migrationBuilder.DropTable(
                name: "UserSeriesSwitch");

            migrationBuilder.DropTable(
                name: "WorkingFields");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropTable(
                name: "CsomorPersons");

            migrationBuilder.DropTable(
                name: "CsomorWorks");

            migrationBuilder.DropTable(
                name: "MovieCategories");

            migrationBuilder.DropTable(
                name: "NotificationTypes");

            migrationBuilder.DropTable(
                name: "SeriesCategories");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "WorkingDays");

            migrationBuilder.DropTable(
                name: "Csomors");

            migrationBuilder.DropTable(
                name: "NotificationSystems");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "WorkingDayTypes");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}

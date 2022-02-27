using AutoMapper;
using CsomorGenerator.Profiles;
using CsomorGenerator.Services;
using CsomorGenerator.Services.Interfaces;
using DinkToPdf;
using DinkToPdf.Contracts;
using KarcagS.Common.Tools;
using KarcagS.Common.Tools.Email;
using KarcagS.Common.Tools.Export.CSV;
using KarcagS.Common.Tools.Export.Excel;
using KarcagS.Common.Tools.Export.PDF;
using KarcagS.Common.Tools.HttpInterceptor;
using KarcagS.Common.Tools.Services;
using ManagerAPI.DataAccess;
using ManagerAPI.Domain.Entities;
using ManagerAPI.Services.Common.Excel;
using ManagerAPI.Services.Common.PDF;
using ManagerAPI.Services.Configurations;
using ManagerAPI.Services.Profiles;
using ManagerAPI.Services.Services;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StatusLibrary.Services.Profiles;
using StatusLibrary.Services.Services;
using StatusLibrary.Services.Services.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JWTConfiguration>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        b =>
        {
            b
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins(builder.Configuration.GetValue("SecureClientUrl", "https://localhost:5001"), builder.Configuration.GetValue("ClientUrl", "http://localhost:5000"));
        });
});

var mapperConfig = new MapperConfiguration(x =>
{
    x.AddProfile(new UserProfile());
    x.AddProfile(new NotificationProfile());
    x.AddProfile(new FriendProfile());
    x.AddProfile(new MessageProfile());
    x.AddProfile(new NewsProfile());
    x.AddProfile(new TaskProfile());
    x.AddProfile(new WorkingDayProfile());
    x.AddProfile(new WorkingFieldProfile());
    x.AddProfile(new WorkingDayTypeProfile());
    x.AddProfile(new MovieProfile());
    x.AddProfile(new BookProfile());
    x.AddProfile(new SeriesProfile());
    x.AddProfile(new GenderProfile());
    x.AddProfile(new CsomorProfile());
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddLogging();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUtilsService, UtilsService<DatabaseContext>>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IFriendService, FriendService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ILoggerService, LoggerService>();
builder.Services.AddScoped<IWorkingDayService, WorkingDayService>();
builder.Services.AddScoped<IWorkingDayTypeService, WorkingDayTypeService>();
builder.Services.AddScoped<IWorkingFieldService, WorkingFieldService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<ISeasonService, SeasonService>();
builder.Services.AddScoped<IEpisodeService, EpisodeService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<ICsvService, CsvService>();
builder.Services.AddScoped<IExcelService, ExcelService>();
builder.Services.AddScoped<ICsomorExcelService, CsomorExcelService>();
builder.Services.AddScoped<IMovieCategoryService, MovieCategoryService>();
builder.Services.AddScoped<IMovieCommentService, MovieCommentService>();
builder.Services.AddScoped<ISeriesCategoryService, SeriesCategoryService>();
builder.Services.AddScoped<ISeriesCommentService, SeriesCommentService>();
builder.Services.AddScoped<IGeneratorService, GeneratorService>();
builder.Services.AddScoped<IPDFService, PDFService>();
builder.Services.AddScoped<ICsomorPDFService, CsomorPDFService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// TODO: Fix
// new CustomAssemblyLoadContext().LoadUnmanagedLibrary($"{Directory.GetCurrentDirectory()}/assets/dll/libwkhtmltox.dll");
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDbContextPool<DatabaseContext>(options =>
{
    options.UseLazyLoadingProxies().UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")));
});

builder.Services.AddIdentity<User, WebsiteRole>(o => o.Stores.MaxLengthForKeys = 128)
    .AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

byte[] key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:JwtSecret"]);

builder.Services.AddAuthentication(x =>
{
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
});

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new TimeSpanConverter()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // app.UseDeveloperExceptionPage();
}

app.UseHttpInterceptor();

app.UseAuthentication();

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
using Blazored.LocalStorage;
using EventManager.Client;
using EventManager.Client.Models;
using EventManager.Client.Services;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using KarcagS.Blazor.Common.Services;
using KarcagS.Blazor.Common.Store;
using ManagerAPI.Shared.DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpService(config =>
{
    config.IsTokenBearer = true;
    config.UnauthorizedPath = "/auth/logout";
    config.AccessTokenName = "access-token";
    config.IsTokenRefresher = true;
    config.RefreshTokenName = "refresh-token";
    config.RefreshUri = builder.Configuration.GetSection("RefreshUri").Value;
    config.RefreshTokenPlaceholder = ":refreshToken";
    config.ClientIdName = "client-id";
    config.ClientIdPlaceholder = ":clientId";
});
builder.Services.AddStoreService(async (storeService, localStorage) =>
{
    var user = await localStorage.GetItemAsync<TokenDTO>("user");

    if (user != null)
    {
        storeService.Add("user", user);
    }
});
builder.Services.AddBlazoredLocalStorage(config =>
{
    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
    config.JsonSerializerOptions.WriteIndented = false;
});

builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHelperService, HelperService>();
builder.Services.AddScoped<IToasterService, ToasterService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IFriendService, FriendService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IWorkingDayService, WorkingDayService>();
builder.Services.AddScoped<IWorkingFieldService, WorkingFieldService>();
builder.Services.AddScoped<IWorkingDayTypeService, WorkingDayTypeService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<ISeasonService, SeasonService>();
builder.Services.AddScoped<IEpisodeService, EpisodeService>();
builder.Services.AddScoped<IMovieCategoryService, MovieCategoryService>();
builder.Services.AddScoped<IMovieCommentService, MovieCommentService>();
builder.Services.AddScoped<ISeriesCategoryService, SeriesCategoryService>();
builder.Services.AddScoped<ISeriesCommentService, SeriesCommentService>();
builder.Services.AddScoped<IGeneratorService, GeneratorService>();

ApplicationSettings.BaseUrl = builder.Configuration.GetSection("Api").Value;
ApplicationSettings.BaseApiUrl = ApplicationSettings.BaseUrl + "/api";

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

await builder.Build().RunAsync();
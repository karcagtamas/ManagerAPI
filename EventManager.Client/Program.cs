using Blazored.LocalStorage;
using EventManager.Client.Http;
using EventManager.Client.Models;
using EventManager.Client.Services;
using EventManager.Client.Services.Interfaces;
using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EventManager.Client
{

    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {

        /// <summary>
        /// Main
        /// </summary>
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("app");

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped(
                sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IHelperService, HelperService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<INotificationService, NotificationService>();
            builder.Services.AddScoped<IFriendService, FriendService>();
            builder.Services.AddScoped<IModalService, ModalService>();
            builder.Services.AddScoped<IHttpService, HttpService>();
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

            // TODO: Add my lib

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
        }
    }
}
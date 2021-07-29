using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MudBlazor;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class HelperService : IHelperService
    {
        private const string NA = "N/A";
        private readonly NavigationManager _navigationManager;
        private readonly ISnackbar _snackbar;

        /// <summary>
        /// Init Helper Service
        /// </summary>
        /// <param name="navigationManager">Navigation manager</param>
        /// <param name="snackbar">Snacbar manager</param>
        public HelperService(NavigationManager navigationManager, ISnackbar snackbar)
        {
            this._navigationManager = navigationManager;
            this._snackbar = snackbar;
        }

        /// <inheritdoc />
        public void Navigate(string path)
        {
            this._navigationManager.NavigateTo(path);
        }

        /// <inheritdoc />
        public JsonSerializerOptions GetSerializerOptions()
        {
            return new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        /// <inheritdoc />
        public async Task AddToaster(HttpResponseMessage response, string caption)
        {
            if (response.IsSuccessStatusCode)
            {
                _snackbar.Add($"<h5>{caption}</h5><h6>Event successfully accomplished</h6>", Severity.Success);
            }
            else
            {
                using (var sr = await response.Content.ReadAsStreamAsync())
                {
                    var e = await System.Text.Json.JsonSerializer.DeserializeAsync<ErrorResponse>(sr, this.GetSerializerOptions());
                    _snackbar.Add($"<h5>{caption}</h5><h6>{e.Message}</h6>");
                }
            }
        }

        /// <inheritdoc />
        public decimal MinToHour(int min)
        {
            return min / (decimal)60;
        }

        /// <inheritdoc />
        public int CurrentYear()
        {
            return DateTime.Today.Year;
        }

        /// <inheritdoc />
        public int CurrentMonth()
        {
            return DateTime.Today.Month;
        }

        /// <inheritdoc />
        public DateTime CurrentWeek()
        {
            var date = DateTime.Today;
            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(-1);
            }

            return date;
        }
    }
}
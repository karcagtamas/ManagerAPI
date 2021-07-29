using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{

    /// <summary>
    /// Helper Service
    /// </summary>
    public interface IHelperService
    {
        /// <summary>
        /// Navigate
        /// </summary>
        /// <param name="path">Destination path</param>
        void Navigate(string path);

        /// <summary>
        /// Predefined serialized options
        /// </summary>
        /// <returns>Option object</returns>
        JsonSerializerOptions GetSerializerOptions();

        /// <summary>
        /// Add toaster
        /// </summary>
        /// <param name="response">HTTP Response</param>
        /// <param name="caption">Caption</param>
        Task AddToaster(HttpResponseMessage response, string caption);

        /// <summary>
        /// Convert minutes to hours
        /// </summary>
        /// <param name="min">Source minutes</param>
        /// <returns>Hours</returns>
        decimal MinToHour(int min);

        /// <summary>
        /// Get current year
        /// </summary>
        /// <returns>Current year</returns>
        int CurrentYear();

        /// <summary>
        /// Get current month
        /// </summary>
        /// <returns>Current month as number</returns>
        int CurrentMonth();

        /// <summary>
        /// Get current week
        /// </summary>
        /// <returns>First day of the week</returns>
        DateTime CurrentWeek();
    }
}
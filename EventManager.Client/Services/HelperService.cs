using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EventManager.Client.Models;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace EventManager.Client.Services {
    public class HelperService : IHelperService {
        private readonly NavigationManager _navigationManager;
        private readonly string UnreachableMessage = "Connection is unreachable! Please try again later!";
        private readonly IMatToaster _toaster;

        public HelperService (NavigationManager navigationManager, IMatToaster toaster) {
            _navigationManager = navigationManager;
            _toaster = toaster;
        }

        public string ConnectionIsUnreachable () {
            return this.UnreachableMessage;
        }

        public void Navigate (string path) {
            _navigationManager.NavigateTo (path);
        }

        public string DateToString (DateTime date) {
            return $"{date.Year}-{LeaderZero(date.Month)}-{LeaderZero(date.Day)} {LeaderZero(date.Hour)}:{LeaderZero(date.Minute)}:{LeaderZero(date.Second)}";
        }

        public string LeaderZero (int number) {
            return number.ToString ().PadLeft (2, '0');
        }

        public string WriteNullableField (object fieldValue) {
            return fieldValue == null ? "-" : fieldValue.ToString ();
        }

        public string WriteForint (decimal? fieldValue) {
            return fieldValue == null? "-": $"{fieldValue} Ft";
        }

        public StringContent CreateContent (object obj) {
            return new StringContent (JsonConvert.SerializeObject (obj), Encoding.UTF8, "application/json");
        }

        public JsonSerializerOptions GetSerializerOptions () {
            return new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task AddToaster (HttpResponseMessage response, string caption) {
            if (response.IsSuccessStatusCode) {
                _toaster.Add ("Event successfully accomplished", MatToastType.Success, caption);
            } else {
                using (var sr = await response.Content.ReadAsStreamAsync ()) {
                    var e = await System.Text.Json.JsonSerializer.DeserializeAsync<ErrorResponse> (sr, GetSerializerOptions ());
                    _toaster.Add (e.Message, MatToastType.Danger, caption);
                }
            }
        }
    }
}
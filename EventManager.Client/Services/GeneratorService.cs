using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.DTOs.CSM;
using ManagerAPI.Shared.Enums;
using ManagerAPI.Shared.Models.CSM;

namespace EventManager.Client.Services
{
    /// <inheritdoc />
    public class GeneratorService : IGeneratorService
    {
        private readonly IHttpService _http;
        private readonly string _url = $"{ApplicationSettings.BaseApiUrl}/csomor";

        /// <summary>
        /// Init Generator Service
        /// </summary>
        /// <param name="httpService">HTTP Service</param>
        public GeneratorService(IHttpService httpService)
        {
            this._http = httpService;
        }

        /// <inheritdoc />
        public Task<bool> ChangePublicStatus(int id, GeneratorPublishModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);
            pathParams.Add("publish");

            var settings = new HttpSettings(this._url).AddPathParams(pathParams).AddToaster("Public status changing");

            var body = new HttpBody<GeneratorPublishModel>(model);

            return this._http.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public Task<int> Create(GeneratorSettingsModel model)
        {
            var settings = new HttpSettings(this._url).AddToaster("Generator setting creating");

            var body = new HttpBody<GeneratorSettingsModel>(model);

            return this._http.PostInt(settings, body).ExecuteWithResult();
        }

        /// <inheritdoc />
        public Task<bool> Delete(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(this._url).AddPathParams(pathParams).AddToaster("Generator setting deleting");

            return this._http.Delete(settings).Execute();
        }

        /// <inheritdoc />
        public Task<bool> ExportPdf(int id, ExportSettingsModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);
            pathParams.Add("export");
            pathParams.Add("pdf");

            var settings = new HttpSettings(this._url).AddPathParams(pathParams).AddToaster("Exporting to PDF");

            return this._http.Download(settings, model);
        }

        /// <inheritdoc />
        public Task<bool> ExportXls(int id, ExportSettingsModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);
            pathParams.Add("export");
            pathParams.Add("xls");

            var settings = new HttpSettings(this._url).AddPathParams(pathParams).AddToaster("Exporting to XLS");

            return this._http.Download(settings, model);
        }

        /// <inheritdoc />
        public Task<GeneratorSettings?> GenerateSimple(GeneratorSettings settings)
        {
            var httpSettings = new HttpSettings(this._http.BuildUrl(this._url, "generate")).AddToaster("Csomor generating");

            var body = new HttpBody<GeneratorSettings>(settings);

            return this._http.PutWithResult<GeneratorSettings, GeneratorSettings>(httpSettings, body).ExecuteWithResult();
        }

        /// <inheritdoc />
        public Task<GeneratorSettings?> Get(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(this._url).AddPathParams(pathParams);

            return this._http.Get<GeneratorSettings>(settings).ExecuteWithResult();
        }

        /// <inheritdoc />
        public async Task<List<UserShortDto>> GetCorrectPersonsForSharing(int id, string name)
        {
            var queryParams = new HttpQueryParameters();
            queryParams.Add("name", name);

            var settings = new HttpSettings(_http.BuildUrl(this._url, id.ToString(), "shared", "correct")).AddQueryParams(queryParams);

            return await this._http.Get<List<UserShortDto>>(settings).ExecuteWithResult() ?? new List<UserShortDto>();
        }

        /// <inheritdoc />
        public async Task<List<CsomorListDTO>> GetOwnedList()
        {
            var settings = new HttpSettings(this._http.BuildUrl(this._url, "my"));

            return await this._http.Get<List<CsomorListDTO>>(settings).ExecuteWithResult() ?? new List<CsomorListDTO>();
        }

        /// <inheritdoc />
        public async Task<List<CsomorListDTO>> GetPublicList()
        {
            var settings = new HttpSettings(this._http.BuildUrl(this._url, "public"));

            return await this._http.Get<List<CsomorListDTO>>(settings).ExecuteWithResult() ?? new List<CsomorListDTO>();
        }

        /// <inheritdoc />
        public Task<CsomorRole> GetRole(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);
            pathParams.Add("role");

            var settings = new HttpSettings(this._url).AddPathParams(pathParams);

            return this._http.Get<CsomorRole>(settings).ExecuteWithResult();
        }

        /// <inheritdoc />
        public async Task<List<CsomorListDTO>> GetSharedList()
        {
            var settings = new HttpSettings(this._http.BuildUrl(this._url, "shared"));

            return await this._http.Get<List<CsomorListDTO>>(settings).ExecuteWithResult() ?? new List<CsomorListDTO>();
        }

        /// <inheritdoc />
        public async Task<List<CsomorAccessDTO>> GetSharedPersonList(int id)
        {
            var settings = new HttpSettings($"{this._url}/{id}/shared");

            return await this._http.Get<List<CsomorAccessDTO>>(settings).ExecuteWithResult() ?? new List<CsomorAccessDTO>();
        }

        /// <inheritdoc />
        public Task<bool> Share(int id, List<CsomorAccessModel> models)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);
            pathParams.Add("share");

            var settings = new HttpSettings(this._url).AddPathParams(pathParams).AddToaster("Csomor sharing");

            var body = new HttpBody<List<CsomorAccessModel>>(models);

            return this._http.Put(settings, body).Execute();
        }

        /// <inheritdoc />
        public Task<bool> Update(int id, GeneratorSettingsModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id);

            var settings = new HttpSettings(this._url).AddPathParams(pathParams).AddToaster("Generator setting updating");

            var body = new HttpBody<GeneratorSettingsModel>(model);

            return this._http.Put(settings, body).Execute();
        }
    }
}

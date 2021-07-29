using EventManager.Client.Http;
using EventManager.Client.Models;
using EventManager.Client.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.DTOs.CSM;
using ManagerAPI.Shared.Enums;
using ManagerAPI.Shared.Models.CSM;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            pathParams.Add(id, -1);
            pathParams.Add("publish", -1);

            var settings = new HttpSettings($"{this._url}", null, pathParams, "Public status changing");

            var body = new HttpBody<GeneratorPublishModel>(model);

            return this._http.Update<GeneratorPublishModel>(settings, body);
        }

        /// <inheritdoc />
        public Task<int> Create(GeneratorSettingsModel model)
        {
            var settings = new HttpSettings($"{this._url}", null, null, "Generator setting creating");

            var body = new HttpBody<GeneratorSettingsModel>(model);

            return this._http.CreateInt<GeneratorSettingsModel>(settings, body);
        }

        /// <inheritdoc />
        public Task<bool> Delete(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this._url}", null, pathParams, "Generator setting deleting");

            return this._http.Delete(settings);
        }

        /// <inheritdoc />
        public Task<bool> ExportPdf(int id, ExportSettingsModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id, -1);
            pathParams.Add("export", -1);
            pathParams.Add("pdf", -1);

            var settings = new HttpSettings($"{this._url}", null, pathParams, "Exporting to PDF");

            return this._http.Download(settings, model);
        }

        /// <inheritdoc />
        public Task<bool> ExportXls(int id, ExportSettingsModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id, -1);
            pathParams.Add("export", -1);
            pathParams.Add("xls", -1);

            var settings = new HttpSettings($"{this._url}", null, pathParams, "Exporting to XLS");

            return this._http.Download(settings, model);
        }

        /// <inheritdoc />
        public Task<GeneratorSettings> GenerateSimple(GeneratorSettings settings)
        {
            var httpSettings = new HttpSettings($"{this._url}/generate", null, null, "Csomor generating");

            var body = new HttpBody<GeneratorSettings>(settings);

            return this._http.UpdateWithResult<GeneratorSettings, GeneratorSettings>(httpSettings, body);
        }

        /// <inheritdoc />
        public Task<GeneratorSettings> Get(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this._url}", null, pathParams);

            return this._http.Get<GeneratorSettings>(settings);
        }

        /// <inheritdoc />
        public Task<List<UserShortDto>> GetCorrectPersonsForSharing(int id, string name)
        {
            var queryParams = new HttpQueryParameters();
            queryParams.Add<string>("name", name);

            var settings = new HttpSettings($"{this._url}/{id}/shared/correct", queryParams, null);

            return this._http.Get<List<UserShortDto>>(settings);
        }

        /// <inheritdoc />
        public Task<List<CsomorListDTO>> GetOwnedList()
        {
            var settings = new HttpSettings($"{this._url}/my");

            return this._http.Get<List<CsomorListDTO>>(settings);
        }

        /// <inheritdoc />
        public Task<List<CsomorListDTO>> GetPublicList()
        {
            var settings = new HttpSettings($"{this._url}/public");

            return this._http.Get<List<CsomorListDTO>>(settings);
        }

        /// <inheritdoc />
        public Task<CsomorRole> GetRole(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id, -1);
            pathParams.Add("role", -1);

            var settings = new HttpSettings($"{this._url}", null, pathParams);

            return this._http.Get<CsomorRole>(settings);
        }

        /// <inheritdoc />
        public Task<List<CsomorListDTO>> GetSharedList()
        {
            var settings = new HttpSettings($"{this._url}/shared");

            return this._http.Get<List<CsomorListDTO>>(settings);
        }

        /// <inheritdoc />
        public Task<List<CsomorAccessDTO>> GetSharedPersonList(int id)
        {
            var settings = new HttpSettings($"{this._url}/{id}/shared");

            return this._http.Get<List<CsomorAccessDTO>>(settings);
        }

        /// <inheritdoc />
        public Task<bool> Share(int id, List<CsomorAccessModel> models)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id, -1);
            pathParams.Add("share", -1);

            var settings = new HttpSettings($"{this._url}", null, pathParams, "Csomor sharing");

            var body = new HttpBody<List<CsomorAccessModel>>(models);

            return this._http.Update<List<CsomorAccessModel>>(settings, body);
        }

        /// <inheritdoc />
        public Task<bool> Update(int id, GeneratorSettingsModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add(id, -1);

            var settings = new HttpSettings($"{this._url}", null, pathParams, "Generator setting updating");

            var body = new HttpBody<GeneratorSettingsModel>(model);

            return this._http.Update<GeneratorSettingsModel>(settings, body);
        }
    }
}

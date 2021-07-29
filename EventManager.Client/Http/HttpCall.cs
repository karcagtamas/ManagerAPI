using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Http
{
    /// <summary>
    /// HTTP Call
    /// </summary>
    public class HttpCall<TList, TSimple, TModel> : IHttpCall<TList, TSimple, TModel>
    {
        /// <summary>
        /// HTTP Service
        /// </summary>
        protected readonly IHttpService Http;

        /// <summary>
        /// Uri
        /// </summary>
        protected readonly string Url;
        private readonly string _caption;

        /// <summary>
        /// Init Generator Service
        /// </summary>
        /// <params name="http">HTTP Service</params>
        /// <params name="url">Uri</params>
        /// <params name="caption">Caption</params>
        protected HttpCall(IHttpService http, string url, string caption)
        {
            this.Http = http;
            this.Url = url;
            this._caption = caption;
        }

        /// <inheritdoc />
        public async Task<List<TList>> GetAll(string orderBy, string direction = "asc")
        {
            var queryParams = new HttpQueryParameters();
            if (!string.IsNullOrEmpty(orderBy))
            {
                queryParams.Add("orderBy", orderBy);
            }

            if (!string.IsNullOrEmpty(direction))
            {
                queryParams.Add("direction", direction);
            }

            var settings = new HttpSettings($"{this.Url}", queryParams, null);

            return await this.Http.Get<List<TList>>(settings);
        }

        /// <inheritdoc />
        public async Task<TSimple> Get(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this.Url}", null, pathParams);

            return await this.Http.Get<TSimple>(settings);
        }

        /// <inheritdoc />
        public async Task<bool> Create(TModel model)
        {
            var settings = new HttpSettings($"{this.Url}", null, null, $"{this._caption} adding");

            var body = new HttpBody<TModel>(model);

            return await this.Http.Create<TModel>(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> Update(int id, TModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this.Url}", null, pathParams, $"{this._caption} updating");

            var body = new HttpBody<TModel>(model);

            return await this.Http.Update<TModel>(settings, body);
        }

        /// <inheritdoc />
        public async Task<bool> Delete(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this.Url}", null, pathParams, $"{this._caption} deleting");

            return await this.Http.Delete(settings);
        }
    }
}
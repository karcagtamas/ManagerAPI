﻿using System.Collections.Generic;
using System.Threading.Tasks;
using EventManager.Client.Models.Interfaces;
using EventManager.Client.Services.Interfaces;

namespace EventManager.Client.Http
{
    public class HttpCall<TList, TSimple, TModel> : IHttpCall<TList, TSimple, TModel>
    {
        protected readonly IHttpService Http;
        protected readonly string Url;
        private readonly string _caption;

        protected HttpCall(IHttpService http, string url, string caption)
        {
            this.Http = http;
            this.Url = url;
            this._caption = caption;
        }

        public async Task<List<TList>> GetAll()
        {
            var settings = new HttpSettings($"{this.Url}");

            return await this.Http.Get<List<TList>>(settings);
        }

        public async Task<TSimple> Get(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this.Url}", null, pathParams);

            return await this.Http.Get<TSimple>(settings);
        }

        public async Task<bool> Create(TModel model)
        {
            var settings = new HttpSettings($"{this.Url}", null, null, $"{this._caption} adding");

            var body = new HttpBody<TModel>(model);

            return await this.Http.Create<TModel>(settings, body);
        }

        public async Task<bool> Update(int id, TModel model)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this.Url}", null, pathParams, $"{this._caption} updating");

            var body = new HttpBody<TModel>(model);

            return await this.Http.Update<TModel>(settings, body);
        }

        public async Task<bool> Delete(int id)
        {
            var pathParams = new HttpPathParameters();
            pathParams.Add<int>(id, -1);

            var settings = new HttpSettings($"{this.Url}", null, pathParams, $"{this._caption} deleting");

            return await this.Http.Delete(settings);
        }
    }
}
using System;

namespace EventManager.Client.Http
{
    /// <summary>
    /// HTTP Settings
    /// </summary>
    public class HttpSettings
    {
        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Query params
        /// </summary>
        public HttpQueryParameters QueryParameters { get; set; }

        /// <summary>
        /// Path params
        /// </summary>
        public HttpPathParameters PathParameters { get; set; }

        /// <summary>
        /// Toaster settings
        /// </summary>
        public ToasterSettings ToasterSettings { get; set; }

        /// <summary>
        /// Settins only with url.
        /// </summary>
        /// <param name="url">Url</param>
        public HttpSettings(string url)
        {
            this.SetUrl(url);
            this.QueryParameters = new HttpQueryParameters();
            this.PathParameters = new HttpPathParameters();
            this.ToasterSettings = new ToasterSettings();
        }

        /// <summary>
        /// Setting with url, query and path params
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="queryParameters">Query parameters</param>
        /// <param name="pathParameters">Path parameters</param>
        public HttpSettings(string url, HttpQueryParameters queryParameters, HttpPathParameters pathParameters)
        {
            this.SetUrl(url);
            this.QueryParameters = queryParameters == null ? new HttpQueryParameters() : queryParameters;
            this.PathParameters = pathParameters == null ? new HttpPathParameters() : pathParameters;
            this.ToasterSettings = new ToasterSettings();
        }

        /// <summary>
        /// Setting with url, query and path params and toaster settings
        /// </summary>
        /// <param name="url"></param>
        /// <param name="queryParameters">Query parameters</param>
        /// <param name="pathParameters">Path parameters</param>
        /// <param name="toasterSettings">Toaster settings</param>
        public HttpSettings(string url, HttpQueryParameters queryParameters, HttpPathParameters pathParameters, ToasterSettings toasterSettings)
        {
            this.SetUrl(url);
            this.QueryParameters = queryParameters == null ? new HttpQueryParameters() : queryParameters;
            this.PathParameters = pathParameters == null ? new HttpPathParameters() : pathParameters;
            this.ToasterSettings = toasterSettings == null ? new ToasterSettings() : toasterSettings;
        }

        /// <summary>
        /// Setting with url, query and path params and toaster caption
        /// </summary>
        /// <param name="url"></param>
        /// <param name="queryParameters">Query parameters</param>
        /// <param name="pathParameters">Path parameters</param>
        /// <param name="toasterCaption">Caption</param>
        public HttpSettings(string url, HttpQueryParameters queryParameters, HttpPathParameters pathParameters, string toasterCaption)
        {
            this.SetUrl(url);
            this.QueryParameters = queryParameters == null ? new HttpQueryParameters() : queryParameters;
            this.PathParameters = pathParameters == null ? new HttpPathParameters() : pathParameters;
            this.ToasterSettings = string.IsNullOrEmpty(toasterCaption) ? new ToasterSettings() : new ToasterSettings(toasterCaption);
        }

        /// <summary>
        /// Set Url. 
        /// If it is invalid, throw an exception.
        /// </summary>
        /// <param name="url">New url</param>
        private void SetUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Invalid url");
            }
            this.Url = url;
        }
    }
}
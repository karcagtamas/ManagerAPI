using Microsoft.AspNetCore.Builder;

namespace ManagerAPI.Backend.Middlewares
{
    /// <summary>
    /// Exception handler Extension
    /// </summary>
    public static class ExceptionHandlerExtensions
    {
        /// <summary>
        /// Using extension for registration
        /// </summary>
        /// <param name="app">App builder</param>
        /// <returns>App builder</returns>
        public static IApplicationBuilder UseMyExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandler>();
        }
    }
}
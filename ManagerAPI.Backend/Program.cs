using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Reflection;

namespace ManagerAPI.Backend
{
    /// <summary>
    /// Program
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args">Args</param>
        public static void Main(string[] args)
        {
            CreateWebHost(args).Run();
        }

        private static IWebHost CreateWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location) ?? string.Empty)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();
        }
    }
}
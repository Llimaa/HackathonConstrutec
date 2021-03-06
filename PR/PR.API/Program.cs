﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace PR.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSetting("detailedErrors", "true")
                // .UseKestrel(options => { options.Limits.MaxRequestBodySize = 524288; })
                .UseIISIntegration();

    }
}

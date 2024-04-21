using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BookBarn.API.Startup))]

namespace BookBarn.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            // app.UseCors("AllowFrontend");


        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddCors(options =>
        //    {
        //        options.AddPolicy("AllowFrontend", builder =>
        //        {
        //            builder.WithOrigins("http://localhost:4200")
        //                   .AllowAnyHeader()
        //                   .AllowAnyMethod();
        //        });
        //    });

        //}
    }
}

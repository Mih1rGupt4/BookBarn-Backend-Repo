using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(BookBarn.API.Startup))]

namespace BookBarn.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            ////////////////
            ///
            // Enable CORS
            // Configure Web API
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            // Enable CORS
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            // Use Web API
            app.UseWebApi(config);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;

[assembly: OwinStartup(typeof(BookBarn.API.Startup))]

namespace BookBarn.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //var issuer = "https://localhost:44392/";
            //var audience = "https://localhost:44392/";
            //var secret = "your_secret_key"; 

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryverylongandsecuresecretkeythatshouldbeusedforjwtgeneration"))
            };

            var options = new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = tokenValidationParameters
            };

            app.UseJwtBearerAuthentication(options);
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

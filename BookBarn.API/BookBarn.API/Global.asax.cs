using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BookBarn.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();

            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = jsonSettings;
        }

        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    // Add the CORS header to the response
        //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "");

        //    // If it is a preflight (OPTIONS) request, add other necessary headers and end the request
        //    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
        //    {
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Authorization, Accept");
        //        HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000"); // Cache for 20 days, adjust as necessary
        //        HttpContext.Current.Response.End();
        //    }
        //}

        //protected void Application_EndRequest()
        //{
        //    if (Response.Headers.AllKeys.Contains("Access-Control-Allow-Origin"))
        //    {
        //        return;
        //    }
        //    Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:4200");
        //    // Repeat for other CORS headers as necessary
        //}


    }
}

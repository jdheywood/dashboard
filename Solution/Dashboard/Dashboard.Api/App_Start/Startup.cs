﻿using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Owin;
using Dashboard.Api;

using WebConfigurationManager = System.Web.Configuration.WebConfigurationManager;

[assembly: OwinStartup(typeof(Startup))]

namespace Dashboard.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var issuer = WebConfigurationManager.AppSettings["Auth0Domain"];
            var audience = WebConfigurationManager.AppSettings["Auth0ClientID"];
            var secret = TextEncodings.Base64Url.Decode(WebConfigurationManager.AppSettings["Auth0ClientSecret"]);

            app.UseCors(CorsOptions.AllowAll);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audience },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                    },
                });

            HttpConfiguration configuration = new HttpConfiguration();

            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            app.UseWebApi(configuration);
        }
    }
}

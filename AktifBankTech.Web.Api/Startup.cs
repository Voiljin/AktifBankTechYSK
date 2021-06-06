using AktifBankTech.Business.DependecyInjectionMapping;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(AktifBankTech.Web.Api.Startup))]

namespace AktifBankTech.Web.Api
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthServerOptions;

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration webApiConfiguration = new HttpConfiguration();
            ConfigureOAuth(app);

            WebApiConfig.Register(webApiConfiguration);

            app.UseWebApi(webApiConfiguration);

            app.UseNinjectMiddleware(DI.CreateKernel);
            app.UseNinjectWebApi(webApiConfiguration);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}

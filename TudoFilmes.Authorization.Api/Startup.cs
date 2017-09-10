using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Web;
using System.Web.Http;
using TudoFilmes.Authorization.Api.Formats;
using TudoFilmes.Authorization.Api.Providers;
using TudoFilmes.Authorization.Infra.CrossCutting.IoC;

namespace TudoFilmes.Authorization.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // Configurações do simple injector
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            BootStrapper.RegisterServices(container);

            // Necessário para registrar o ambiente do Owin que é dependência do Identity
            // Feito fora da camada de IoC para não levar o System.Web para fora
            container.Register(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying)
                {
                    return new OwinContext().Authentication;
                }
                return HttpContext.Current.GetOwinContext().Authentication;

            });

            // Não utilizar o Verify devido a solicitação dinamica de dependências.
            //container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            config.DependencyResolver.BeginScope();

            config.MapHttpAttributeRoutes();

            ConfigureOAuth(app, config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, HttpConfiguration config)
        {

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthProvider(config),
                AccessTokenFormat = new CustomJwtFormat("http://lele.com.br", config)
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);

        }
    }
}
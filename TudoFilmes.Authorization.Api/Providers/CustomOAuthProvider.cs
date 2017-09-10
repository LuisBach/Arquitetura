using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using TudoFilmes.Authorization.Application.Interfaces;

namespace TudoFilmes.Authorization.Api.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IClienteAppService _clienteAppService;

        public CustomOAuthProvider(HttpConfiguration config)
        {
            _usuarioAppService = (IUsuarioAppService)config.DependencyResolver.GetService(typeof(IUsuarioAppService));
            _clienteAppService = (IClienteAppService)config.DependencyResolver.GetService(typeof(IClienteAppService));
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            string symmetricKeyAsBase64 = string.Empty;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                context.SetError("invalid_clientId", "client_id não foi informado.");
                return;
            }

            var cliente = await _clienteAppService.ObterPorClientIdAssincrono(context.ClientId);

            if (cliente == null)
            {
                context.SetError("invalid_clientId", string.Format("client_id '{0}' inválido.", context.ClientId));
                return;
            }

            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var retorno = await _usuarioAppService.ValidarLogin(context.UserName, context.Password);

            if (!retorno.ValidationResult.IsValid)
            {
                context.SetError("invalid_grant", retorno.ValidationResult.Erros.FirstOrDefault().Message);
                return;
            }

            var identity = new ClaimsIdentity("JWT");

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Manager"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Supervisor"));

            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                         "audience", (context.ClientId == null) ? string.Empty : context.ClientId
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);
        }
    }
}
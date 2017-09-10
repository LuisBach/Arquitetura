using System.Web.Http;
using TudoFilmes.Authorization.Api.Utils;
using TudoFilmes.Authorization.Application.Interfaces;
using TudoFilmes.Authorization.Application.ViewModels;

namespace TudoFilmes.Authorization.Api.Controllers
{
    [RoutePrefix("api/clientes")]
    public class ClientesController : BaseApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Adicionar(ClienteCadastroViewModel clienteCadastroViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(Erros);

            var credenciais = GeradorCredenciais.Gerar();
            clienteCadastroViewModel.ClientId = credenciais.ClientId;
            clienteCadastroViewModel.Base64Secret = credenciais.Base64Secret;

            clienteCadastroViewModel = _clienteAppService.Adicionar(clienteCadastroViewModel);

            if (!clienteCadastroViewModel.ValidationResult.IsValid)
            {
                AdicionarErros(clienteCadastroViewModel.ValidationResult);
                return BadRequest(Erros);
            }

            return Ok(clienteCadastroViewModel);
        }
    }
}

using System.Web.Http;
using TudoFilmes.Authorization.Application.Interfaces;
using TudoFilmes.Authorization.Infra.CrossCutting.Identity.Model;

namespace TudoFilmes.Authorization.Api.Controllers
{
    [RoutePrefix("api/contas")]
    public class ContasController : BaseApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public ContasController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [Route("registrar")]
        public IHttpActionResult Registrar([FromBody] RegisterViewModel registerViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var usuarioViewModel = _usuarioAppService.Adicionar(registerViewModel);

                if (!usuarioViewModel.ValidationResult.IsValid)
                {
                    AdicionarErros(usuarioViewModel.ValidationResult);
                    return BadRequest(ModelState);
                }

                return Ok(usuarioViewModel);
            }
            catch
            {
                return BadRequest(mensagemErroSistema);
            }
        }
    }
}

using DomainValidation.Validation;
using System;
using System.Web.Http;

namespace TudoFilmes.Resource.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        public const string mensagemErroSistema = "Ocorreu um erro ao tentar realizar a sua solicitação. Tente novamente daqui à alguns minutos!";

        public void AdicionarErros(ValidationResult erros)
        {
            if (erros == null) throw new InvalidOperationException();

            foreach (var erro in erros.Erros)
            {
                ModelState.AddModelError("Erros", erro.Message);
            }
        }
    }
}

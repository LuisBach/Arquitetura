using DomainValidation.Validation;
using System;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace TudoFilmes.Authorization.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        public const string mensagemErroSistema = "Ocorreu um erro ao tentar realizar a sua solicitação. Tente novamente daqui alguns minutos!";
        public ModelStateDictionary Erros
        {
            get
            {
                var errosRetorno = new ModelStateDictionary();

                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        errosRetorno.AddModelError("Erros", error.ErrorMessage);
                    }
                }

                return errosRetorno;
            }
        }

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

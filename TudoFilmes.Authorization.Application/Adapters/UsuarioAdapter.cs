using DomainValidation.Validation;
using System.Collections.Generic;
using System.Linq;
using TudoFilmes.Authorization.Application.ViewModels;

namespace TudoFilmes.Authorization.Application.Adapters
{
    public class UsuarioAdapter
    {
        public static UsuarioViewModel ToUsuarioViewModel(string mensagemSucesso)
        {
            return new UsuarioViewModel()
            {
                ValidationResult = new ValidationResult() { Message = mensagemSucesso }
            };
        }

        public static UsuarioViewModel ToUsuarioViewModel(List<string> erros)
        {
            var validationResult = new ValidationResult();

            foreach (var item in erros.Select(e => new ValidationError(e)).ToList())
            {
                validationResult.Add(item);
            }

            return new UsuarioViewModel()
            {
                ValidationResult = validationResult
            };
        }
    }
}

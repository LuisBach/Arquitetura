using System.ComponentModel.DataAnnotations;
namespace TudoFilmes.Authorization.Application.ViewModels
{
    public class UsuarioViewModel
    {
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TudoFilmes.Authorization.Application.ViewModels
{
    public class ClienteCadastroViewModel
    {
        [MaxLength(100)]
        [Required]
        public string Nome { get; set; }

        public string ClientId { get; set; }

        public string Base64Secret { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}

using DomainValidation.Validation;
using TudoFilmes.Authorization.Domain.Validations.Clientes;

namespace TudoFilmes.Authorization.Domain.Entities
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string ClientId { get; set; }
        public string Base64Secret { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

using DomainValidation.Validation;
using TudoFilmes.Authorization.Domain.Entities;
using TudoFilmes.Authorization.Domain.Specifications.Clientes;

namespace TudoFilmes.Authorization.Domain.Validations.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var clienteBase64Secret = new ClienteDeveTerBase64SecretSpecification();
            var clientId = new ClienteDeveTerClientIdSpecification();
            var clienteNome = new ClienteDeveTerNomeSpecification();

            base.Add("clientId", new Rule<Cliente>(clientId, "O clientId do cliente é inválido."));
            base.Add("clienteBase64Secret", new Rule<Cliente>(clienteBase64Secret, "O clientSecret do cliente é inválido."));
            base.Add("clienteNome", new Rule<Cliente>(clienteNome, "O cliente não possui nome."));
        }
    }
}

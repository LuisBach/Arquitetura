using DomainValidation.Validation;
using TudoFilmes.Authorization.Domain.Entities;
using TudoFilmes.Authorization.Domain.Interfaces.Repository;
using TudoFilmes.Authorization.Domain.Specifications.Clientes;

namespace TudoFilmes.Authorization.Domain.Validations.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var clienteExistente = new ClienteDevePossuirNomeUnicoSpecification(clienteRepository);

            base.Add("clienteExistente", new Rule<Cliente>(clienteExistente, "Cliente já existente."));
        }
    }
}

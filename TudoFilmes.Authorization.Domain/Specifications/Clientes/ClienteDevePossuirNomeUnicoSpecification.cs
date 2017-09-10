using DomainValidation.Interfaces.Specification;
using TudoFilmes.Authorization.Domain.Entities;
using TudoFilmes.Authorization.Domain.Interfaces.Repository;

namespace TudoFilmes.Authorization.Domain.Specifications.Clientes
{
    public class ClienteDevePossuirNomeUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirNomeUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterPorNome(cliente.Nome) == null;
        }
    }
}

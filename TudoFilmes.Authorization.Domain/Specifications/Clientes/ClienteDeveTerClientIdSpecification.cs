using DomainValidation.Interfaces.Specification;
using System;
using TudoFilmes.Authorization.Domain.Entities;

namespace TudoFilmes.Authorization.Domain.Specifications.Clientes
{
    public class ClienteDeveTerClientIdSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return !string.IsNullOrEmpty(cliente.ClientId);
        }
    }
}

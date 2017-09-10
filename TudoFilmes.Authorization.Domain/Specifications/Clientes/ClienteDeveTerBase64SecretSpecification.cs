using DomainValidation.Interfaces.Specification;
using System;
using TudoFilmes.Authorization.Domain.Entities;

namespace TudoFilmes.Authorization.Domain.Specifications.Clientes
{
    public class ClienteDeveTerBase64SecretSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return !string.IsNullOrEmpty(cliente.Base64Secret);
        }
    }
}

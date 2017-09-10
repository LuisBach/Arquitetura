using System;
using TudoFilmes.Authorization.Domain.Entities;
using TudoFilmes.Authorization.Domain.Specifications.Clientes;
using Xunit;

namespace TudoFilmes.Authorization.Domain.Tests.Specifications.Clientes
{
    public class ClientIdSpecificationTest
    {
        [Fact]
        public void ClientId_Valido_Verdadeiro()
        {
            // Arrange
            var especificacao = new ClienteDeveTerClientIdSpecification();
            var cliente = new Cliente()
            {
                Nome = "Cliente",
                ClientId = "099153c2625149bc8ecb3e85e03f0022",
                Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw"
            };

            // Act
            var valido = especificacao.IsSatisfiedBy(cliente);

            // Assert
            Assert.True(valido);
        }

        [Fact]
        public void ClientId_Valido_Falso()
        {
            // Arrange
            var especificacao = new ClienteDeveTerClientIdSpecification();
            var cliente = new Cliente()
            {
                ClientId = "",
                Nome = "Cliente"
            };

            // Act
            var valido = especificacao.IsSatisfiedBy(cliente);

            // Assert
            Assert.False(valido);
        }
    }
}

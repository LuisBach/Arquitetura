using System;
using TudoFilmes.Authorization.Domain.Entities;
using Xunit;

namespace TudoFilmes.Authorization.Domain.Tests.Entities
{
    // Cliente consistente
    // Cliente não consistente

    public class ClienteTests
    {
        [Fact]
        public void Cliente_Consistente_Verdadeiro()
        {
            // Arrange
            var cliente = new Cliente()
            {
                Nome = "Cliente consistente",
                ClientId = "099153c2625149bc8ecb3e85e03f0022",
                Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw"
            };

            // Act
            var valido = cliente.IsValid();

            // Assert
            Assert.True(valido);
        }

        [Fact]
        public void Cliente_Consistente_Falso()
        {
            // Arrange
            var cliente = new Cliente()
            {
                ClientId = "099153c2625149bc8ecb3e85e03f0022",
                Nome = "Cliente consistente"
            };

            // Act
            var valido = cliente.IsValid();

            // Assert
            Assert.False(valido);
        }
    }
}

using Moq;
using System;
using TudoFilmes.Authorization.Domain.Entities;
using TudoFilmes.Authorization.Domain.Interfaces.Repository;
using TudoFilmes.Authorization.Domain.Validations.Clientes;
using Xunit;

namespace TudoFilmes.Authorization.Domain.Tests.Validations
{
    public class ClienteAptoParaCadastroTest
    {
        [Fact]
        public void ClienteApto_Validacao_Valido()
        {
            // Arrange
            var clienteExistente = new Cliente()
            {
                ClientId = "099153c2625149bc8ecb3e85e03f0022",
                Nome = "nome existente",
                Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw"
            };

            var clienteNovo = new Cliente()
            {
                ClientId = "099153c2625149bc8ecb3e85e03f0022",
                Nome = "nome novo",
                Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw"
            };

            var repo = new Mock<IClienteRepository>();
            repo.Setup(r => r.ObterPorNome(clienteExistente.Nome)).Returns(clienteExistente);

            // Act
            var validacao = new ClienteAptoParaCadastroValidation(repo.Object);

            // Assert
            Assert.True(validacao.Validate(clienteNovo).IsValid);
        }

        [Fact]
        public void ClienteApto_Validacao_Invalido()
        {
            // Arrange
            var clienteExistente = new Cliente()
            {
                ClientId = "099153c2625149bc8ecb3e85e03f0022",
                Nome = "nome existente",
                Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw"
            };

            var clienteNovo = new Cliente()
            {
                ClientId = "099153c2625149bc8ecb3e85e03f0022",
                Nome = "nome existente",
                Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw"
            };

            var repo = new Mock<IClienteRepository>();
            repo.Setup(r => r.ObterPorNome(clienteExistente.Nome)).Returns(clienteExistente);

            // Act
            var validacao = new ClienteAptoParaCadastroValidation(repo.Object);

            // Assert
            Assert.False(validacao.Validate(clienteNovo).IsValid);
        }
    }
}

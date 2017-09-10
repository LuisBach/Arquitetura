using Moq;
using System;
using TudoFilmes.Authorization.Domain.Entities;
using TudoFilmes.Authorization.Domain.Interfaces.Repository;
using TudoFilmes.Authorization.Domain.Services;
using Xunit;

namespace TudoFilmes.Authorization.Domain.Tests.Services
{
    // Consultar cliente existente
    // Consultar cliente inexistente
    // Cadastrar cliente
    // Nao deve permitir cadastrar cliente sem nome
    // Nao deve permitir cadastrar cliente com mesmo nome

    public class ClienteServiceTests
    {
        [Fact]
        public void ClienteService_Consultar_RetornarClienteCadastrado()
        {
            // Arrange
            var repo = new Mock<IClienteRepository>();
            var cliente = new Cliente();
            repo.Setup(r => r.ObterPorClientId("099153c2625149bc8ecb3e85e03f0022")).Returns(cliente);

            var clienteService = new ClienteService(repo.Object);

            // Act
            var retorno = clienteService.ObterPorClientIdAssincrono("099153c2625149bc8ecb3e85e03f0022");

            // Assert
            Assert.NotNull(retorno);
        }

        [Fact]
        public void ClienteService_Consultar_RetornarClienteNulo()
        {
            // Arrange
            var repo = new Mock<IClienteRepository>();
            var cliente = new Cliente();
            repo.Setup(r => r.ObterPorClientId("099153c2625149bc8ecb3e85e03f0022")).Returns(cliente);

            var clienteService = new ClienteService(repo.Object);

            // Act
            var retorno = clienteService.ObterPorClientId("099153c2625149bc8ecb3e85e03f0023");

            // Assert
            Assert.Null(retorno);
        }

        [Fact]
        public void ClienteService_Adicionar_Sucesso()
        {
            // Arrange
            var repo = new Mock<IClienteRepository>();

            var cliente = new Cliente()
            {
                ClientId = "099153c2625149bc8ecb3e85e03f0022",
                Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw",
                Nome = "Novo Cliente"
            };

            repo.Setup(r => r.Adicionar(cliente)).Returns(cliente);
            var clienteService = new ClienteService(repo.Object);

            // Act
            var valido = clienteService.Adicionar(cliente).ValidationResult.IsValid;

            // Assert
            Assert.True(valido);
        }

        [Fact]
        public void ClienteService_Adicionar_NaoAdicionado()
        {
            // Arrange
            var repo = new Mock<IClienteRepository>();

            var cliente = new Cliente()
            {
                ClientId = "",
                Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw",
                Nome = "Novo Cliente"
            };

            repo.Setup(r => r.Adicionar(cliente)).Returns(cliente);
            var clienteService = new ClienteService(repo.Object);

            // Act
            var valido = clienteService.Adicionar(cliente).ValidationResult.IsValid;

            // Assert
            Assert.False(valido);
        }
    }
}

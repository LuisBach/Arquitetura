using Moq;
using System;
using TudoFilmes.Authorization.Domain.Entities;
using TudoFilmes.Authorization.Domain.Interfaces.Repository;
using TudoFilmes.Authorization.Domain.Specifications.Clientes;
using Xunit;

namespace TudoFilmes.Authorization.Domain.Tests.Specifications.Clientes
{
    public class NomeUnicoSpecificationTest
    {
        [Fact]
        public void NomeUnico_Valido_Verdadeiro()
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

            var especificacao = new ClienteDevePossuirNomeUnicoSpecification(repo.Object);

            // Act
            var valido = especificacao.IsSatisfiedBy(clienteNovo);

            // Assert
            Assert.True(valido);
        }

        [Fact]
        public void NomeUnico_Valido_Falso()
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

            var especificacao = new ClienteDevePossuirNomeUnicoSpecification(repo.Object);

            // Act
            var valido = especificacao.IsSatisfiedBy(clienteNovo);

            // Assert
            Assert.False(valido);
        }
    }
}

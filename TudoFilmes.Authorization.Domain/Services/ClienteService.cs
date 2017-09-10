using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TudoFilmes.Authorization.Domain.Entities;
using TudoFilmes.Authorization.Domain.Interfaces.Repository;
using TudoFilmes.Authorization.Domain.Interfaces.Service;
using TudoFilmes.Authorization.Domain.Validations.Clientes;

namespace TudoFilmes.Authorization.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public Cliente ObterPorClientId(string clientId)
        {
            return _clienteRepository.ObterPorClientId(clientId);
        }

        public async Task<Cliente> ObterPorClientIdAssincrono(string clientId)
        {
            return await _clienteRepository.ObterPorClientIdAssincrono(clientId);
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.IsValid())
            {
                return cliente;
            }

            cliente.ValidationResult = new ClienteAptoParaCadastroValidation(_clienteRepository).Validate(cliente);
            if (!cliente.ValidationResult.IsValid)
            {
                return cliente;
            }

            cliente.ValidationResult.Message = "Cliente cadastrado com sucesso!";
            return _clienteRepository.Adicionar(cliente);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

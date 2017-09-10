using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TudoFilmes.Authorization.Application.Adapters;
using TudoFilmes.Authorization.Application.Interfaces;
using TudoFilmes.Authorization.Application.ViewModels;
using TudoFilmes.Authorization.Domain.Interfaces.Service;
using TudoFilmes.Authorization.Infra.Data.Interfaces;

namespace TudoFilmes.Authorization.Application
{
    public class ClienteAppService : ApplicationService, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork uow)
            : base(uow)
        {
            _clienteService = clienteService;
        }

        public ClienteCadastroViewModel Adicionar(ClienteCadastroViewModel clienteCadastroViewModel)
        {
            var cliente = ClienteAdapter.ToCliente(clienteCadastroViewModel);

            BeginTransaction();

            cliente = _clienteService.Adicionar(cliente);
            clienteCadastroViewModel = ClienteAdapter.ToClienteCadastroViewModel(cliente);

            if (!cliente.ValidationResult.IsValid)
            {
                return clienteCadastroViewModel;
            }

            Commit();

            return clienteCadastroViewModel;
        }

        public ClienteViewModel ObterPorClientId(string clientId)
        {
            return ClienteAdapter.ToClienteViewModel(_clienteService.ObterPorClientId(clientId));
        }

        public async Task<ClienteViewModel> ObterPorClientIdAssincrono(string clientId)
        {
            var cliente = await _clienteService.ObterPorClientIdAssincrono(clientId);
            return ClienteAdapter.ToClienteViewModel(cliente);
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

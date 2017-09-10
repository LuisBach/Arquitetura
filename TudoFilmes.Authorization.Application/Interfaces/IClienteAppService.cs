using System;
using System.Threading.Tasks;
using TudoFilmes.Authorization.Application.ViewModels;

namespace TudoFilmes.Authorization.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteCadastroViewModel Adicionar(ClienteCadastroViewModel clienteCadastroViewModel);
        ClienteViewModel ObterPorClientId(string clientId);
        Task<ClienteViewModel> ObterPorClientIdAssincrono(string clientId);
    }
}

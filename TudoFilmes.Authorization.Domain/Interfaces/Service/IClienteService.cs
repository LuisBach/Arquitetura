using System;
using System.Threading.Tasks;
using TudoFilmes.Authorization.Domain.Entities;

namespace TudoFilmes.Authorization.Domain.Interfaces.Service
{
    public interface IClienteService : IDisposable
    {
        Cliente ObterPorId(Guid id);
        Cliente ObterPorClientId(string clientId);
        Task<Cliente> ObterPorClientIdAssincrono(string clientId);
        Cliente Adicionar(Cliente cliente);
    }
}

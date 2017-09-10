using System.Threading.Tasks;
using TudoFilmes.Authorization.Domain.Entities;

namespace TudoFilmes.Authorization.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorNome(string nome);
        Cliente ObterPorClientId(string clientId);
        Task<Cliente> ObterPorClientIdAssincrono(string clientId);
    }
}

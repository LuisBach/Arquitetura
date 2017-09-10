using System.Linq;
using System.Threading.Tasks;
using TudoFilmes.Authorization.Domain.Entities;
using TudoFilmes.Authorization.Domain.Interfaces.Repository;
using TudoFilmes.Authorization.Infra.Data.Context;

namespace TudoFilmes.Authorization.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {

        public ClienteRepository(TudoFilmesContext context)
            : base(context)
        {

        }

        public Cliente ObterPorNome(string nome)
        {
            return Buscar(c => c.Nome == nome).FirstOrDefault();
        }

        public Cliente ObterPorClientId(string clientId)
        {
            return Buscar(c => c.ClientId == clientId).FirstOrDefault();
        }

        public async Task<Cliente> ObterPorClientIdAssincrono(string clientId)
        {
            var resultado = await BuscarAssincrono(c => c.ClientId == clientId);
            return resultado.FirstOrDefault();
        }
    }
}

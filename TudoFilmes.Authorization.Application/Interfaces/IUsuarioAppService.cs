using System.Threading.Tasks;
using TudoFilmes.Authorization.Application.ViewModels;
using TudoFilmes.Authorization.Infra.CrossCutting.Identity.Model;

namespace TudoFilmes.Authorization.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        UsuarioViewModel Adicionar(RegisterViewModel registerViewModel);
        Task<UsuarioViewModel> ValidarLogin(string userName, string senha);
    }
}

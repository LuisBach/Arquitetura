using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using TudoFilmes.Authorization.Application;
using TudoFilmes.Authorization.Application.Interfaces;
using TudoFilmes.Authorization.Domain.Interfaces.Repository;
using TudoFilmes.Authorization.Domain.Interfaces.Service;
using TudoFilmes.Authorization.Domain.Services;
using TudoFilmes.Authorization.Infra.CrossCutting.Identity.Configuration;
using TudoFilmes.Authorization.Infra.CrossCutting.Identity.Context;
using TudoFilmes.Authorization.Infra.CrossCutting.Identity.Model;
using TudoFilmes.Authorization.Infra.Data.Context;
using TudoFilmes.Authorization.Infra.Data.Interfaces;
using TudoFilmes.Authorization.Infra.Data.Repository;
using TudoFilmes.Authorization.Infra.Data.UoW;

namespace TudoFilmes.Authorization.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            // Infra Dados
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);

            // Configurações de unidade de trabalho e contexto.
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<TudoFilmesContext>(Lifestyle.Scoped);

            // Identity
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
        }
    }
}

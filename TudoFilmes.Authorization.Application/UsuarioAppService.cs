using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TudoFilmes.Authorization.Application.Adapters;
using TudoFilmes.Authorization.Application.Interfaces;
using TudoFilmes.Authorization.Application.ViewModels;
using TudoFilmes.Authorization.Infra.CrossCutting.Identity.Configuration;
using TudoFilmes.Authorization.Infra.CrossCutting.Identity.Context;
using TudoFilmes.Authorization.Infra.CrossCutting.Identity.Model;
using TudoFilmes.Authorization.Infra.Data.Interfaces;

namespace TudoFilmes.Authorization.Application
{
    public class UsuarioAppService : ApplicationService, IUsuarioAppService
    {
        private ApplicationUserManager _userManager;

        public UsuarioAppService(IUnitOfWork uow, ApplicationUserManager userManager) : base(uow)
        {
            _userManager = userManager;
        }


        public UsuarioViewModel Adicionar(RegisterViewModel registerViewModel)
        {
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext()) { AutoSaveChanges = false };
            var manager = _userManager;

            var user = new ApplicationUser { UserName = registerViewModel.Email, Email = registerViewModel.Email };
            var result = manager.Create(user, registerViewModel.Password);

            if (result.Succeeded)
            {
                return UsuarioAdapter.ToUsuarioViewModel("Cadastro realizado com sucesso!");
            }
            else
            {
                var errosBr = new List<string>();

                foreach (var erro in result.Errors)
                {
                    string erroBr;
                    if (erro.Contains("Passwords must have at least one digit ('0'-'9')."))
                    {
                        erroBr = "A senha precisa ter ao menos um dígito";
                        errosBr.Add(erroBr);
                    }
                    if (erro.Contains("Passwords must have at least one non letter or digit character."))
                    {
                        erroBr = "A senha precisa ter ao menos um caractere especial (@, #, etc...)";
                        errosBr.Add(erroBr);
                    }
                    if (erro.Contains("Passwords must have at least one lowercase ('a'-'z')."))
                    {
                        erroBr = "A senha precisa ter ao menos uma letra em minúsculo";
                        errosBr.Add(erroBr);
                    }
                    if (erro.Contains("Passwords must have at least one uppercase ('A'-'Z')."))
                    {
                        erroBr = "A senha precisa ter ao menos uma letra em maiúsculo";
                        errosBr.Add(erroBr);
                    }
                    if (erro.Contains("Name " + registerViewModel.Email + " is already taken"))
                    {
                        erroBr = "E-mail já registrado, esqueceu sua senha?";
                        errosBr.Add(erroBr);
                    }
                }

                return UsuarioAdapter.ToUsuarioViewModel(errosBr);
            }
        }

        public async Task<UsuarioViewModel> ValidarLogin(string userName, string senha)
        {
            var usuario = await _userManager.FindAsync(userName, senha);

            if (usuario == null) return UsuarioAdapter.ToUsuarioViewModel(new List<string>() { "Login ou Senha incorretos." });
            if (await _userManager.IsLockedOutAsync(usuario.Id)) return UsuarioAdapter.ToUsuarioViewModel(new List<string>() { "Usuário bloqueado no sistema." });

            return UsuarioAdapter.ToUsuarioViewModel("");
        }
    }
}

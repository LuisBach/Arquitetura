using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TudoFilmes.Authorization.Infra.CrossCutting.Identity.Configuration
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Habilitar o envio de e-mail
            if (false)
            {
                // Injetar Servico de Email e utilizar
            }

            return Task.FromResult(0);
        }
    }
}
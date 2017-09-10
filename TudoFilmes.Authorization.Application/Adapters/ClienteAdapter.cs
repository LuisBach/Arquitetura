using System.Threading.Tasks;
using TudoFilmes.Authorization.Application.ViewModels;
using TudoFilmes.Authorization.Domain.Entities;

namespace TudoFilmes.Authorization.Application.Adapters
{
    public class ClienteAdapter
    {
        public static ClienteCadastroViewModel ToClienteCadastroViewModel(Cliente cliente)
        {
            if (cliente == null) return null;

            return new ClienteCadastroViewModel()
            {
                Nome = cliente.Nome,
                Base64Secret = cliente.Base64Secret,
                ClientId = cliente.ClientId,
                ValidationResult = cliente.ValidationResult
            };
        }

        public static ClienteViewModel ToClienteViewModel(Cliente cliente)
        {
            if (cliente == null) return null;

            var clienteViewModel = new ClienteViewModel()
            {
                ClientId = cliente.ClientId,
                Base64Secret = cliente.Base64Secret,
                Nome = cliente.Nome
            };

            return clienteViewModel;
        }

        public static Cliente ToCliente(ClienteCadastroViewModel clienteCadastroViewModel)
        {
            if (clienteCadastroViewModel == null) return null;

            return new Cliente()
            {
                Nome = clienteCadastroViewModel.Nome,
                Base64Secret = clienteCadastroViewModel.Base64Secret,
                ClientId = clienteCadastroViewModel.ClientId
            };
        }

    }
}

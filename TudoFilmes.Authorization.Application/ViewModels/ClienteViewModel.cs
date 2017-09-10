using System;

namespace TudoFilmes.Authorization.Application.ViewModels
{
    public class ClienteViewModel
    {
        public string Nome { get; set; }
        public string ClientId { get; set; }
        public string Base64Secret { get; set; }
    }
}

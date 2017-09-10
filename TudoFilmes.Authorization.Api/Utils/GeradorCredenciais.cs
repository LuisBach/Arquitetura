using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Security.Cryptography;

namespace TudoFilmes.Authorization.Api.Utils
{
    public class GeradorCredenciais
    {
        public static Credenciais Gerar()
        {
            var key = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(key);
            var base64Secret = TextEncodings.Base64Url.Encode(key);

            return new Credenciais()
            {
                ClientId = Guid.NewGuid().ToString("N"),
                Base64Secret = base64Secret
            };
        }
    }

    public class Credenciais
    {
        public string ClientId { get; set; }
        public string Base64Secret { get; set; }
    }
}
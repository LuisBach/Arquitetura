using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TudoFilmes.Authorization.Infra.CrossCutting.Identity.Configuration
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Utilizando TWILIO como SMS Provider.
            // https://www.twilio.com/docs/quickstart/csharp/sms/sending-via-rest

            const string accountSid = "SEU ID";
            const string authToken = "SEU TOKEN";

            //var client = new TwilioRestClient(accountSid, authToken);

            //client.SendMessage("Seu Telefone", message.Destination, message.Body);

            TwilioClient.Init(accountSid, authToken);

            MessageResource.CreateAsync(
                from: new PhoneNumber("Seu Telefone"),
                to: new PhoneNumber(message.Destination),
                body: message.Body);

            return Task.FromResult(0);
        }
    }
}
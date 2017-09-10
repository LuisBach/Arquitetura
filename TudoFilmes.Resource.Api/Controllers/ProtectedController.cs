using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using TudoFilmes.Authorization.Application.Interfaces;

namespace TudoFilmes.Resource.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/protected")]
    public class ProtectedController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public ProtectedController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [Route("")]
        public IEnumerable<object> Get()
        {
            var identity = User.Identity as ClaimsIdentity;

            return identity.Claims.Select(c => new
            {
                Type = c.Type,
                Value = c.Value
            });
        }
    }
}

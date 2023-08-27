using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sentry;

namespace WebApi.Areas.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentryController : ControllerBase
    {
        //private readonly IHub _sentryHub;

        //public SentryController(IHub sentryHub) => _sentryHub = sentryHub;

        [HttpGet("/person/{id}")]
        public IActionResult Person(string id)
        {

            throw new NullReferenceException("Agora vai");
            return Ok();
        }
    }
}

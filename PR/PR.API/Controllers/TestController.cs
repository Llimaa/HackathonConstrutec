using Microsoft.AspNetCore.Mvc;

namespace PR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Testdebug";
        }
    }
}

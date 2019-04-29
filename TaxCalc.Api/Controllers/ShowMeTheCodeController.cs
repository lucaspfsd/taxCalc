using Microsoft.AspNetCore.Mvc;

namespace TaxCalc.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get() => Ok("https://github.com/lucaspfsd/taxCalc/");
    }
}

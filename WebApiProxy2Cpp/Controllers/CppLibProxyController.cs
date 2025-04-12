using Microsoft.AspNetCore.Mvc;

namespace WebApiProxy2Cpp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CppLibProxyController : ControllerBase
    {
       

        private readonly ILogger<CppLibProxyController> _logger;

        public CppLibProxyController(ILogger<CppLibProxyController> logger)
        {
            _logger = logger;
        }

        [HttpPost()]
        public int SumInts(int[] NumbersToSum)
        {
           return NumbersToSum.Sum(x => x);
        }
    }
}

using MathLibContract;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebApiProxy2Cpp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CppLibProxyController : ControllerBase
    {
       

        private readonly ILogger<CppLibProxyController> _logger;
        private readonly IMathLibService _mathLibService;

        public CppLibProxyController(ILogger<CppLibProxyController> logger, IMathLibService mathLibService)
        {
            _logger = logger;
            _mathLibService = mathLibService;
        }

        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> SumInts(int[] NumbersToSum)
        {
            if (NumbersToSum.Length == 0) { return 0; }
            if ((NumbersToSum.Last() == 0) && !NumbersToSum.Any(n => n == 0)) _mathLibService.SumInts(NumbersToSum);
            return _mathLibService.SumInts(NumbersToSum.Where(n => n != 0).Union(new int[] { 0 }).ToArray());
        }
    }
}

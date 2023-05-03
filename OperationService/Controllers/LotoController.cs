using Microsoft.AspNetCore.Mvc;

namespace OperationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LotoController : ControllerBase
    {
        private readonly ILogger<LotoController> _logger;

        public LotoController(ILogger<LotoController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetLoto")]
        //public IEnumerable<IActionResult> Get()
        //{
        //    return null;
        //}
    }
}
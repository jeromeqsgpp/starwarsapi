using Microsoft.AspNetCore.Mvc;
using StarWarsStopLightDemoAPI.Services;

namespace StarWarsStopLightDemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StarWarsController : Controller
    {
        private readonly ILogger<StarWarsController> _logger;
        private readonly SwapiService _swapiService;

        public StarWarsController(ILogger<StarWarsController> logger, SwapiService swapiService)
        {
            _logger = logger;
            _swapiService = swapiService ?? throw new ArgumentNullException(nameof(swapiService));
        }

        [HttpGet("people/{id}")]
        public async Task<IActionResult> GetSwapiPerson(int id)
        {
            try
            {
                var swapiPerson = await _swapiService.GetSwapiPersonByIdAsync(id);
                if(swapiPerson == null)
                {
                    return NotFound();
                }
                return Ok(swapiPerson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred!");
                return StatusCode(500,"An error occurred!");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBTICKETSAPPI.Services.Contratos;

namespace WEBTICKETSAPPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AveriasController : ControllerBase
    {
        private readonly IAveriasServices _averiasServices;

        public AveriasController(IAveriasServices averiasServices)
        {
            _averiasServices = averiasServices;
        }

        [HttpGet]
        [Route("GetAverias")]
        public async Task<IActionResult> GetAverias()
        {
            var lista = await _averiasServices.GetAverias();
            return Ok(lista);
        }
    }
}

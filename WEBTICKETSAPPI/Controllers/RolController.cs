using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBTICKETSAPPI.DTO;
using WEBTICKETSAPPI.Services.Contratos;
using WEBTICKETSAPPI.Util;

namespace WEBTICKETSAPPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolServices _rolservices;

        public RolController(IRolServices rolservices)
        {
            _rolservices = rolservices;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<RolDTO>>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _rolservices.Listar();
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPost]
        [Route("Createusuario")]
        public async Task<IActionResult> CreateUsuario([FromBody] RolDTO rol)
        {
            var rps = new Response<RolDTO>();
            try
            {
                var rpta = await _rolservices.CreateRol(rol);
                rps.Value = rol;
                rps.Status = true;
            }
            catch (Exception ex)
            {
                rps.Status = false;
                rps.Msg = ex.Message;
            }
            return Ok(rps);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _rolservices.DeleteRol(id);
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            return Ok(rsp);
        }
    }
}

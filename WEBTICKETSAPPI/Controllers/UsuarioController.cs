using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using WEBTICKETSAPPI.ContextBD;
using WEBTICKETSAPPI.DTO;
using WEBTICKETSAPPI.Services.Contratos;
using WEBTICKETSAPPI.Util;

namespace WEBTICKETSAPPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<UsuarioDTO>>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _usuarioServices.ListUsuario();
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
        public async Task<IActionResult> CreateUsuario([FromBody] UsuarioDTO usuario)
        {
            var rps = new Response<UsuarioDTO>();
            try
            {
                var rpta = await _usuarioServices.CreateUsuario(usuario);
                rps.Value = usuario;
                rps.Status = true;
            }
            catch (Exception ex)
            {
                rps.Status = false;
                rps.Msg = ex.Message;
            }
            return Ok(rps);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO usuario)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _usuarioServices.EditUsuario(usuario);
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.Status = true;
                rsp.Value = await _usuarioServices.DeleteUsuario(id);
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

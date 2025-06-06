using Microsoft.EntityFrameworkCore;
using WEBTICKETSAPPI.ContextBD;
using WEBTICKETSAPPI.DTO;
using WEBTICKETSAPPI.Repositorio.Contratos;
using WEBTICKETSAPPI.Services.Contratos;

namespace WEBTICKETSAPPI.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IGenericRepository<Usuario> _usuarioRepository;

        public UsuarioServices(IGenericRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> CreateUsuario(UsuarioDTO usuario)
        {
            var rpta = false;
            try
            {
                var usuario_nuevo = new Usuario
                {
                    SNombres = usuario.SNombres,
                    SApellPaterno = usuario.SApellPaterno,
                    SApellMaterno = usuario.SApellMaterno,
                    NEstado = 1,
                    ORol = usuario.ORol,
                    SUsername = usuario.SUsername,
                    SPassword = usuario.SPassword
                };

                var usuario_creado = await _usuarioRepository.Crear(usuario_nuevo);
                rpta = true;
            }
            catch
            {
                throw;
            }
            return rpta;
        }
        public async Task<List<UsuarioDTO>> ListUsuario()
        {
            var lista = new List<UsuarioDTO>();
            try
            {
                var usuarios = await _usuarioRepository.Consultar();
                foreach (var usuario in usuarios)
                {
                    lista.Add(new UsuarioDTO
                    {
                        NIdUsuario = usuario.NIdUsuario,
                        SNombres = usuario.SNombres,
                        SApellPaterno = usuario.SApellPaterno,
                        SApellMaterno = usuario.SApellMaterno,
                        NEstado = usuario.NEstado,
                        ORol = usuario.ORol,
                        SUsername = usuario.SUsername,
                        SPassword = usuario.SPassword
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving users.", ex);
            }
            return lista;
        }
        public async Task<bool> EditUsuario(UsuarioDTO usuario)
        {
            var rpta = false;
            try
            {
                var usuarios = await _usuarioRepository.Consultar();
                var usuario_encontrado = usuarios.FirstOrDefault(x => x.NIdUsuario == usuario.NIdUsuario);

                if (usuario_encontrado == null)
                    throw new TaskCanceledException("Usuario no existe");

                usuario_encontrado.SNombres = usuario.SNombres;
                usuario_encontrado.SApellPaterno = usuario.SApellPaterno;
                usuario_encontrado.SApellMaterno = usuario.SApellMaterno;
                usuario_encontrado.NEstado = usuario.NEstado;
                usuario_encontrado.ORol = usuario.ORol;
                usuario_encontrado.SUsername = usuario.SUsername;
                usuario_encontrado.SPassword = usuario.SPassword;

                rpta = await _usuarioRepository.Editar(usuario_encontrado);
            }
            catch
            {
                throw;
            }
            return rpta;
        }
        public async Task<bool> DeleteUsuario(int id)
        {
            try
            {
                var UsuarioEncontrado = await _usuarioRepository.Obtener(u => Convert.ToInt32(u.NIdUsuario) == id);

                if (UsuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");

                bool respuesta = await _usuarioRepository.Eliminar(UsuarioEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }
    }
}

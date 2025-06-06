using WEBTICKETSAPPI.ContextBD;
using WEBTICKETSAPPI.DTO;
using WEBTICKETSAPPI.Repositorio.Contratos;
using WEBTICKETSAPPI.Services.Contratos;

namespace WEBTICKETSAPPI.Services
{
    public class RolServices : IRolServices
    {
        private readonly IGenericRepository<Rol> _rolRepository;

        public RolServices(IGenericRepository<Rol> rolRepository)
        {
            _rolRepository = rolRepository;
        }
        
        public async Task<List<RolDTO>> Listar()
        {
            var lista = new List<RolDTO>();
            try
            {
                var rol = await _rolRepository.Consultar();
                foreach (var item in rol)
                {
                    lista.Add(new RolDTO
                    {
                        NIdRol = item.NIdRol,
                        SNombreRol = item.SNombreRol,
                        SDescripcionRol = item.SDescripcionRol
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving users.", ex);
            }
            return lista;
        }
        public async Task<bool> CreateRol(RolDTO rol)
        {
            var rpta = false;
            try
            {
                var rol_nuevo = new Rol
                {
                    SNombreRol = rol.SNombreRol,
                    SDescripcionRol = rol.SDescripcionRol
                };

                var rol_creado = await _rolRepository.Crear(rol_nuevo);
                rpta = true;
            }
            catch
            {
                throw;
            }
            return rpta;
        }
        public async Task<bool> DeleteRol(int id)
        {
            try
            {
                var rolEncontrado = await _rolRepository.Obtener(u => Convert.ToInt32(u.NIdRol) == id);

                if (rolEncontrado == null)
                    throw new TaskCanceledException("El rol no existe");

                bool respuesta = await _rolRepository.Eliminar(rolEncontrado);

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

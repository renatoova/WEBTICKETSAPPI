using WEBTICKETSAPPI.ContextBD;
using WEBTICKETSAPPI.DTO;

namespace WEBTICKETSAPPI.Services.Contratos
{
    public interface IUsuarioServices
    {
        Task<bool> CreateUsuario(UsuarioDTO usuario);
        Task<List<UsuarioDTO>> ListUsuario();
        Task<bool> EditUsuario(UsuarioDTO usuario);
        Task<bool> DeleteUsuario(int id);
    }
}

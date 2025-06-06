using WEBTICKETSAPPI.DTO;

namespace WEBTICKETSAPPI.Services.Contratos
{
    public interface IRolServices
    {
        Task<List<RolDTO>> Listar();
        Task<bool> CreateRol(RolDTO rol);
        Task<bool> DeleteRol(int id);
    }
}

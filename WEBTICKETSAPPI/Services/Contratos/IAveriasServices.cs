using WEBTICKETSAPPI.ContextBD;

namespace WEBTICKETSAPPI.Services.Contratos
{
    public interface IAveriasServices
    {
        Task<List<Averium>> GetAverias();
    }
}
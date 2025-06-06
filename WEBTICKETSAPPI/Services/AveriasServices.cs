using Microsoft.EntityFrameworkCore;
using WEBTICKETSAPPI.ContextBD;
using WEBTICKETSAPPI.Services.Contratos;

namespace WEBTICKETSAPPI.Services
{
    public class AveriasServices : IAveriasServices
    {
        private readonly AtentodbContext _atentodbContext;

        public AveriasServices(AtentodbContext atentodbContext)
        {
            _atentodbContext = atentodbContext;
        }

        public async Task<List<Averium>> GetAverias()
        {
            var lista = new List<Averium>();
            try
            {
                lista = await _atentodbContext.Averia.ToListAsync();
            }
            catch (Exception ex)
            {
                lista = new List<Averium>();
                throw new Exception("An error occurred while retrieving averias.", ex);
            }
            return lista;
        }
    }
}

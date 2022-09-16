using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITipoGastoViajeRepository
    {
        Task<IEnumerable<TipoGastoViajeEntity>> GetTipoGastoViajeEntities();
        Task<IEnumerable<TipoGastoViajeEntity>> GetTipoGastoViajeEntities(string empresa);
        Task PostTipoGastoViaje(TipoGastoViajeEntity tipo);

        Task PutTipoGastoViaje(int id, TipoGastoViajeEntity tipo);
    }
}

using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICategoriaTipoGastoViajeRepository
    {
        Task<IEnumerable<CategoriaTipoGastoViajeEntity>> GetCategoriaTipoGastoViajeEntities();
        Task<IEnumerable<CategoriaTipoGastoViajeEntity>> GetCategoriaTipoGastoViajeEntities(string empresa);
        Task PostCategoriaTipoGastoViaje(CategoriaTipoGastoViajeEntity categoriaTipoGastoViaje);
        Task PutCategoriaGastoViajeDetalle(int id, CategoriaTipoGastoViajeEntity categoria);
    }
}

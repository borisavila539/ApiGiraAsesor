using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEstadosRepository
    {
        Task<IEnumerable<EstadoEntity>> GetEstados();
    }
}

using System.Collections.Generic;

namespace Core.Entities
{
    public class EstadoEntity
    {
        public EstadoEntity()
        {
            GastosViajeDetalle = new HashSet<GastosViajeDetalleEntity>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<GastosViajeDetalleEntity> GastosViajeDetalle { get; set; }
    }
}

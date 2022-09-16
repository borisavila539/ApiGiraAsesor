using System.Collections.Generic;

namespace Core.Entities
{
    public class CategoriaTipoGastoViajeEntity
    {
        public CategoriaTipoGastoViajeEntity()
        {
            GastosViajeDetalle = new HashSet<GastosViajeDetalleEntity>();
        }

        public int IdCategoriaTipoGastoViaje { get; set; }
        public int IdTipoGastoViaje { get; set; }
        public string Nombre { get; set; }
        public string ProveedorPredefinido { get; set; }
        public bool FacturaObligatoria { get; set; }
        public bool Descripcion { get; set; }
        public bool ImagenObligatoria { get; set; }
        public bool Activo { get; set; }

        public virtual TipoGastoViajeEntity IdTipoGastoViajeNavigation { get; set; }
        public virtual ICollection<GastosViajeDetalleEntity> GastosViajeDetalle { get; set; }
    }
}

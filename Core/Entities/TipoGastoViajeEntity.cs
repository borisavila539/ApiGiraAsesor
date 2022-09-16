using System.Collections.Generic;

namespace Core.Entities
{
    public class TipoGastoViajeEntity
    {
        public TipoGastoViajeEntity()
        {
            CategoriaTipoGastoViaje = new HashSet<CategoriaTipoGastoViajeEntity>();
        }

        public int IdTipoGastoViaje { get; set; }
        public string Nombre { get; set; }
        public string Diario { get; set; }
        public string Empresa { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<CategoriaTipoGastoViajeEntity> CategoriaTipoGastoViaje { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class MaestroMonedaEntity
    {
        public string IdMoneda { get; set; }
        public string Moneda { get; set; }
        public string Abreviacion { get; set; }

        public virtual ICollection<MonedasxEmpresaEntity> MonedasxEmpresa { get; set; }
    }
}

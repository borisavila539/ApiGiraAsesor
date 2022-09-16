using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class MonedasxEmpresaEntity
    {
        public int IdMonedaxEmpresa { get; set; }
        public string EmpresaId { get; set; }
        public string IdMoneda { get; set; }

        public virtual MaestroMonedaEntity IdMonedaNavigation { get; set; }
    }
}

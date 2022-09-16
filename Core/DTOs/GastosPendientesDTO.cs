using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class GastosPendientesDTO
    {
        public int IdGastoViajeDetalle { get; set; }
        public string categoria { get; set; }
        public string UsuarioAsesor { get; set; }
        public string Proveedor { get; set; }
        public string NoFactura { get; set; }
        public string Descripcion { get; set; }
        public double ValorFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}

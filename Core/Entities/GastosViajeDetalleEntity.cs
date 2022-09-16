using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class GastosViajeDetalleEntity
    {
        public GastosViajeDetalleEntity()
        {
           
        }

        public int IdGastoViajeDetalle { get; set; }
        public int IdCategoriaTipoGastoViaje { get; set; }
        public string UsuarioAsesor { get; set; }
        public string Proveedor { get; set; }
        public string NoFactura { get; set; }
        public string Descripcion { get; set; }
        public double ValorFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime FechaCreacion { get; set; }
        public byte[] Imagen { get; set; }
        public int? IdEstado { get; set; }
        public string DescripcionAdmin { get; set; }
        public string MensajeAx { get; set; }
        public string DescripcionGasto { get; set; }
        public string Administrador { get; set; }
        public string serie { get; set; }

        public virtual CategoriaTipoGastoViajeEntity IdCategoriaTipoGastoViajeNavigation { get; set; }
        public virtual EstadoEntity IdEstadoNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class EmpresaEntity
    {
        public string EmpresaId { get; set; }
        public string NombreEmpresa { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Logo { get; set; }
        public string Direccion { get; set; }
        public string RegistroTributario { get; set; }
        public bool? Revision { get; set; }
        public string DocumentoFiscal { get; set; }
    }
}

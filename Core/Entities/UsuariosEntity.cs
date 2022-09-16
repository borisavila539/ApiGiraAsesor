using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class UsuariosEntity
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? BloqueoInfoCredito { get; set; }
        public bool? FlagTodosAsesores { get; set; }
        public bool? FlagUsuarioOficina { get; set; }
        public bool? FlagAdministradorProductos { get; set; }
        public bool? SesionActiva { get; set; }
        public bool FlagBodegaEspecifico { get; set; }
        public bool? CorreoDevolucion { get; set; }
        public string Correo { get; set; }

    }
}

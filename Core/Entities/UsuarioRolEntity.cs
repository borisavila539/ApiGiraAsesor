using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class UsuarioRolEntity
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string EditedBy { get; set; }
        public DateTime EditedDate { get; set; }

        public virtual RolesEntity Rol { get; set; }
        public virtual UsuariosEntity Usuario { get; set; }
    }
}

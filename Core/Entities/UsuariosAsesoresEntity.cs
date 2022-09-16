using System;


namespace Core.Entities
{
    public class UsuariosAsesoresEntity
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string CodigoAsesor { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual UsuariosEntity Usuario { get; set; }
    }
}

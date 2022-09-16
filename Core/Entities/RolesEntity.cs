using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class RolesEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}

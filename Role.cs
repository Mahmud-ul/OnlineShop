using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceApp.Model.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Insert the role type")]
        public string Type { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<RoleAccount> RoleAccount { get; set; }
    }
}

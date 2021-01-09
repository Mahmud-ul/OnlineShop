using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Model.Models;

namespace EcommerceApp.ViewModel.Role
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Insert the role type")]
        public string Type { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<EcommerceApp.Model.Models.RoleAccount> RoleAccount { get; set; }
    }
}

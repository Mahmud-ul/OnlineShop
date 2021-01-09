using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Model.Models;

namespace EcommerceApp.ViewModel.Account
{
    public class AccountCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please input your UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please input your FUll Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please input your Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please input your Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please input your Phone number")]
        public int Phone { get; set; }
        public bool Status { get; set; }

        [Required(ErrorMessage = "Please input your Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Confirm your Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public virtual ICollection<EcommerceApp.Model.Models.RoleAccount> RoleAccount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.ViewModel.RoleAccount
{
    public class RoleAccountUpdateViewModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int AccountId { get; set; }
        public bool Status { get; set; }

        public virtual EcommerceApp.Model.Models.Role Role { get; set; }
        public virtual EcommerceApp.Model.Models.Account Account { get; set; }
    }
}

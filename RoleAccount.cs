using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceApp.Model.Models
{
    public class RoleAccount
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int AccountId { get; set; }
        public bool Status { get; set; }

        public virtual Role Role { get; set; }
        public virtual Account Account { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.ViewModel.Product;

namespace EcommerceApp.ViewModel.Brand
{
    public class BrandViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insert Brand Name.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        public bool Status { get; set; }

        public virtual ProductViewModel Products { get; set; }
    }
}

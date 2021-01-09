using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceApp.Model.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insert Brand Name.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        public bool Status { get; set; }

        public virtual Brand Brande { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

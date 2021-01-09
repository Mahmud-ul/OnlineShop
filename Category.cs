using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceApp.Model.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insert Category Name.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Parent Category")]
        public int? MainCat { get; set; }
        public bool Status { get; set; }

        public virtual Category Categorye { get; set; }
        public virtual ICollection<Category> Categorys { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}

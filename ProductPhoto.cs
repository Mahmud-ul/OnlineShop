using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceApp.Model.Models
{
    public class ProductPhoto
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Photo { get; set; }
        public bool Featured { get; set; }
        public bool Status { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}

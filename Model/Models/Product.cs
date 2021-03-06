﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EcommerceApp.Model.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Insert Product Name")]
        [StringLength(50, MinimumLength =2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Insert Price")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Please Insert Quantity")]
        public int Quantity { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ProductPhotosId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotos  { get; set; }
    }

}

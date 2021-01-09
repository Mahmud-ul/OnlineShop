﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.ViewModel.Category
{
    public class CategoryCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Insert Category Name.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        public int? MainCat { get; set; }
        public bool Status { get; set; }
    }
}

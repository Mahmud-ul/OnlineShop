using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceApp.Model.Models
{
    public class SlideShow
    {
        public int Id { get; set; } 
        
        [Required(ErrorMessage ="Please Upload Picture for Slide Show")]
        [StringLength(500, MinimumLength =2)]
        public string Photo { get; set; }
        public bool Status { get; set; }
    }
}

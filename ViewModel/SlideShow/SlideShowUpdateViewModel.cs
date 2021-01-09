using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.ViewModel.SlideShow
{
    public class SlideShowUpdateViewModel
    {
        public int Id { get; set; }
        [StringLength(500, MinimumLength = 2)]
        public string Photo { get; set; }
        public bool Status { get; set; }
    }
}

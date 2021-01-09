using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.ViewModel.ProductPhoto
{
    public class ProductPhotoUpdateViewModel
    {
        public int Id { get; set; }

        [StringLength(500, MinimumLength = 2)]
        public string Photo { get; set; }
        public bool Featured { get; set; }
        public bool Status { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual EcommerceApp.Model.Models.Product Product { get; set; }
    }
}

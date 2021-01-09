using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Model.Models;
using EcommerceApp.Repository.Base;
using EcommerceApp.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Repository
{
    public class ProductPhotoRepository : BaseRepository<ProductPhoto> , IProductPhotoRepository
    {
        public async override Task<IEnumerable<ProductPhoto>>GetAll()
        {
            return await _db.ProductPhotos.Include(p => p.Product).ToListAsync();
        }
    }
}

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
    public class ProductRepository : BaseRepository<Product> , IProductRepository
    {
        public async override Task<IEnumerable<Product>> GetAll()
        {
            return await _db.Products.Include(p => p.Category).Include(b => b.Brand).Include(p => p.ProductPhotos).ToListAsync();             
        }
    }
}

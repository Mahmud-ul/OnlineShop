using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EcommerceApp.Manager.Base;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using EcommerceApp.Repository.Contract;

namespace EcommerceApp.Manager
{
    public class ProductManager : BaseManager<Product>, IProductManager
    {
        private readonly IProductRepository _iProductRepository;

        public ProductManager(IProductRepository iProductRepository) : base(iProductRepository)
        {
            _iProductRepository = iProductRepository;
        }

        public override Task<IEnumerable<Product>> GetAll()
        {
            return _iProductRepository.GetAll();
        }
    }
}

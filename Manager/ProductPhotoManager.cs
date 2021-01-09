using System;
using System.Collections.Generic;
using System.Text;
using EcommerceApp.Manager.Base;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using EcommerceApp.Repository.Contract;

namespace EcommerceApp.Manager
{
    public class ProductPhotoManager : BaseManager<ProductPhoto> , IProductPhotoManager
    {
        private readonly IProductPhotoRepository _iProductPhotoRepository;
        public ProductPhotoManager(IProductPhotoRepository iProductPhotoRepository) : base(iProductPhotoRepository)
        {
            _iProductPhotoRepository = iProductPhotoRepository;
        }
    }
}

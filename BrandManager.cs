using System;
using System.Collections.Generic;
using System.Text;
using EcommerceApp.Manager.Base;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using EcommerceApp.Repository.Contract;

namespace EcommerceApp.Manager
{
    public class BrandManager : BaseManager<Brand>, IBrandManager
    {
        private readonly IBrandRepository _iBrandRepository;

        public BrandManager(IBrandRepository iBrandRepository) : base(iBrandRepository)
        {
            _iBrandRepository = iBrandRepository;
        }
    } 
}

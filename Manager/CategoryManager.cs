using System;
using System.Collections.Generic;
using System.Text;
using EcommerceApp.Manager.Base;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using EcommerceApp.Repository.Contract;

namespace EcommerceApp.Manager
{
    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {
        private readonly ICategoryRepository _iCategoryRepository;

        public CategoryManager(ICategoryRepository iCategoryRepository) : base(iCategoryRepository)
        {
            _iCategoryRepository = iCategoryRepository;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryManager _iCategoryManager;
        public CategoryViewComponent(ICategoryManager iCategoryManager)
        {
            _iCategoryManager = iCategoryManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Category> categories = await _iCategoryManager.GetAll();
            categories = categories.Where(c => c.Status == true).ToList();
            return View(categories);
        }
    }
}

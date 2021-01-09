using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using EcommerceApp.ViewModel.Category;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _iCategoryManager;
        private readonly IMapper _iMapper;       

        public CategoryController(ICategoryManager iCategoryManager, IMapper iMapper)
        {
            _iCategoryManager = iCategoryManager;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Index()
        {
            IEnumerable<CategoryViewModel> getAllCategorys = _iMapper.Map<IEnumerable<CategoryViewModel>>
                                                            (await _iCategoryManager.GetAll());
            return View(getAllCategorys);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateViewModel categoryCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                Category createCategory = _iMapper.Map<Category>(categoryCreateViewModel);
                bool isAdd = await _iCategoryManager.Create(createCategory);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Save Category";
            }
            return View(categoryCreateViewModel);
        }
        [HttpGet]
        public async Task<ActionResult<CategorySubViewModel>> SubCategory(int? id)
        {
            if (id == null)
                return NotFound();

            CategorySubViewModel subCategory = _iMapper.Map<CategorySubViewModel>
                                            (await _iCategoryManager.GetById(id));
            if (subCategory == null)
                return NotFound();
            
            return View(subCategory);
        }

        [HttpPost]
        public async Task<IActionResult> SubCategory(CategorySubViewModel categorySubViewModel, string subCategory)
        {
            if (ModelState.IsValid)
            {
                CategorySubViewModel createSubCategory = new CategorySubViewModel
                {
                    MainCat = categorySubViewModel.Id,
                    Name = subCategory,
                    Status = categorySubViewModel.Status,
                };

                Category createCategory = _iMapper.Map<Category>(createSubCategory);
                bool isAdd = await _iCategoryManager.Create(createCategory);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Save Category";
            }

            return View(categorySubViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<CategoryUpdateViewModel>> Update(int? id)
        {
            if (id == null)
                return NotFound();

            CategoryUpdateViewModel existCategory = _iMapper.Map<CategoryUpdateViewModel>
                                            (await _iCategoryManager.GetById(id));

            if (existCategory == null)
                return NotFound();
            
            return View(existCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateViewModel categoryUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Category updateCategory = _iMapper.Map<Category>(categoryUpdateViewModel);       
                bool isAdd = await _iCategoryManager.Update(updateCategory);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Save Category";
            }

            return View(categoryUpdateViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                return NotFound();

            Category existCategory = await _iCategoryManager.GetById(id);

            if (existCategory == null)
                return NotFound();

            bool remove = await _iCategoryManager.Remove(existCategory);

            if (remove)
                return RedirectToAction("Index");

            return BadRequest();
        }
    }
}



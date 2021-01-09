using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using EcommerceApp.ViewModel.Brand;
using EcommerceApp.ViewModel.Category;
using EcommerceApp.ViewModel.Product;
using EcommerceApp.ViewModel.ProductPhoto;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _iProductManager;
        private readonly ICategoryManager _iCategoryManager;
        private readonly IBrandManager _iBrandManager;
        private readonly IProductPhotoManager _iProductPhotoManager;
        private readonly IMapper _iMapper;

        public ProductController(IProductManager iProductManager, ICategoryManager iCategoryManager, IBrandManager iBrandManager, IProductPhotoManager iProductPhotoManager, IMapper iMapper)
        {
            _iProductManager = iProductManager;
            _iCategoryManager = iCategoryManager;
            _iBrandManager = iBrandManager;
            _iProductPhotoManager = iProductPhotoManager;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
        {
            IEnumerable<ProductViewModel> getProducts = _iMapper.Map<IEnumerable<ProductViewModel>>
                (await _iProductManager.GetAll());

            ViewBag.ProductPhotos = _iMapper.Map<ICollection<ProductPhotoCreateViewModel>>(await _iProductPhotoManager.GetAll());
            return View(getProducts);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.SubCategories = _iMapper.Map<ICollection<CategoryCreateViewModel>>(await _iCategoryManager.GetAll());
            ViewBag.Brands = _iMapper.Map<ICollection<CreateBrandViewModel>>(await _iBrandManager.GetAll());            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel productCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                Product createProduct = _iMapper.Map<Product>(productCreateViewModel);
                bool isAdd = await _iProductManager.Create(createProduct);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Save Product";
            }
            ViewBag.ErrorMessage = "Failed to Save Product";
            ViewBag.SubCategories = _iMapper.Map<ICollection<CategoryCreateViewModel>>(await _iCategoryManager.GetAll());
            ViewBag.Brands = _iMapper.Map<ICollection<CreateBrandViewModel>>(await _iBrandManager.GetAll());
            return View(productCreateViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<ProductUpdateViewModel>> Update(int? id)
        {
            if (id == null)
                return NotFound();

            ProductUpdateViewModel existProduct = _iMapper.Map<ProductUpdateViewModel>
                                            (await _iProductManager.GetById(id));

            if (existProduct == null)
                return NotFound();

            ViewBag.SubCategories = _iMapper.Map<ICollection<CategoryCreateViewModel>>(await _iCategoryManager.GetAll());
            ViewBag.Brands = _iMapper.Map<ICollection<CreateBrandViewModel>>(await _iBrandManager.GetAll());
            return View(existProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateViewModel productUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                Product updateProduct = _iMapper.Map<Product>(productUpdateViewModel);
                bool isAdd = await _iProductManager.Update(updateProduct);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Update";
            }

            ViewBag.ErrorMessage = "Failed to Update Product";
            ViewBag.SubCategories = _iMapper.Map<ICollection<CategoryCreateViewModel>>(await _iCategoryManager.GetAll());
            ViewBag.Brands = _iMapper.Map<ICollection<CreateBrandViewModel>>(await _iBrandManager.GetAll());
            return View(productUpdateViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                return NotFound();

            Product existProduct = await _iProductManager.GetById(id);

            if (existProduct == null)
                return NotFound();

            bool remove = await _iProductManager.Remove(existProduct);

            if (remove)
                return RedirectToAction("Index");

            return BadRequest();
        }
    }
}

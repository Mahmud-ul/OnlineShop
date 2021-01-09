using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using EcommerceApp.ViewModel.Product;
using EcommerceApp.ViewModel.ProductPhoto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class ProductPhotoController : Controller
    {
        private readonly IProductPhotoManager _iProductPhotoManager;
        private readonly IProductManager _iProductManager;
        private readonly IMapper _iMapper;
        [Obsolete]
        private readonly IHostingEnvironment _iHostingEnvironment;

        [Obsolete]
        public ProductPhotoController(IProductPhotoManager iProductPhotoManager, IProductManager iProductManager, IMapper iMapper, IHostingEnvironment iHostingEnvironment)
        {
            _iProductPhotoManager = iProductPhotoManager;
            _iProductManager = iProductManager;
            _iMapper = iMapper;
            _iHostingEnvironment = iHostingEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductPhotoViewModel>>> Index()
        {
            IEnumerable<ProductPhotoViewModel> PhotoList = _iMapper.Map<IEnumerable<ProductPhotoViewModel>>
                            (await _iProductPhotoManager.GetAll());
            ViewBag.Products = _iMapper.Map<IEnumerable<ProductViewModel>>(await _iProductManager.GetAll()); 
            return View(PhotoList);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductPhotoViewModel>>> Index2( int? id)
        {
            if (id == null)
                return NotFound();

            IEnumerable<ProductPhotoViewModel> PhotoList = _iMapper.Map<IEnumerable<ProductPhotoViewModel>>
                            (await _iProductPhotoManager.GetAll());
            ViewBag.ProId = id;
            return View(PhotoList);
        }

        [HttpGet]
        public async Task<ActionResult<ProductPhotoViewModel>> SetFeatured(int? id)
        {
            IEnumerable<ProductPhoto> PhotoList = _iMapper.Map<IEnumerable<ProductPhoto>>
                            (await _iProductPhotoManager.GetAll());
            int proId = -1;
            bool isAdd = false;
            foreach (ProductPhoto item in PhotoList)
            {
                if (item.Id == id)
                {
                    proId = item.ProductId;
                    break;
                }
            }

            foreach (ProductPhoto item in PhotoList)
            {
                if(proId == item.ProductId)
                {
                    if (item.Id == id)
                        item.Featured = true;
                    else
                        item.Featured = false;

                    isAdd = await _iProductPhotoManager.Update(item);
                }   
            }

            if (isAdd)
                return RedirectToAction("Index","Product");
            return ViewBag.ErrorMessage("Failed to Set product Feature");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Products = _iMapper.Map<ICollection<ProductViewModel>>(await _iProductManager.GetAll());
            return View();
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult>Create(ProductPhotoCreateViewModel productPhotoCreateViewModel, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    string NameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath + "/product_photo" , 
                                         Path.GetFileName(photo.FileName));
                    await photo.CopyToAsync(new FileStream(NameAndPath, FileMode.Create));

                    productPhotoCreateViewModel.Photo = "product_photo/" + photo.FileName;
                }
                if (photo == null)
                    productPhotoCreateViewModel.Photo = "product_photo/NoImageFound.jpg";

                ProductPhoto createProductPhoto = _iMapper.Map<ProductPhoto>(productPhotoCreateViewModel);
                bool isAdd = await _iProductPhotoManager.Create(createProductPhoto);
                if(isAdd==true)
                    return RedirectToAction("Index2", new {id = createProductPhoto.ProductId});

                return ViewBag.ErrorMessage("Failed to save product photo");
            }
            return View(productPhotoCreateViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<ProductPhotoUpdateViewModel>>Update(int? id)
        {
            if (id == null)
                return NotFound();

            ProductPhotoUpdateViewModel productPhotoUpdate = _iMapper.Map<ProductPhotoUpdateViewModel>
                                                             (await _iProductPhotoManager.GetById(id));

            if (productPhotoUpdate == null)
                return NotFound();
            ViewBag.Products = _iMapper.Map<ICollection<ProductViewModel>>(await _iProductManager.GetAll());
            return View(productPhotoUpdate);
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Update(ProductPhotoUpdateViewModel productPhotoUpdateViewModel, IFormFile photo, string pht)
        {
            if(ModelState.IsValid)
            {
                if(photo != null)
                {
                    string NameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath +
                                         "/product_photo" , Path.GetFileName(photo.FileName));

                    await photo.CopyToAsync(new FileStream (NameAndPath, FileMode.Create));
                    productPhotoUpdateViewModel.Photo = "product_photo/" + photo.FileName;
                }
                if(photo == null)
                    productPhotoUpdateViewModel.Photo = pht;

                ProductPhoto updateProductPhoto = _iMapper.Map<ProductPhoto>(productPhotoUpdateViewModel);
                bool IsAdd = await _iProductPhotoManager.Update(updateProductPhoto);

                if (IsAdd)
                    return RedirectToAction("Index2", new {id = updateProductPhoto.ProductId});                    

                ViewBag.ErrorMessage = "Failed to Update Product Photo";
            }
            return View(productPhotoUpdateViewModel);
        }

        [HttpGet]
        [Obsolete]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                return NotFound();

            ProductPhoto productPhoto = await _iProductPhotoManager.GetById(id);
            if (productPhoto.Photo != "product_photo/NoImageFound.jpg")
            {
                var PhotoName = productPhoto.Photo;
                var fullPath = Path.Combine(_iHostingEnvironment.WebRootPath + "/" + PhotoName);
                FileInfo fi = new FileInfo(fullPath);
                if (fi != null)
                {
                    System.IO.File.Delete(fullPath);
                    fi.Delete();
                }
            }
            bool remove = await _iProductPhotoManager.Remove(productPhoto);
            if (remove)
                return RedirectToAction("Index");

            return BadRequest();

        }
    }
}

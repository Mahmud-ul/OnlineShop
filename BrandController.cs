using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using EcommerceApp.ViewModel.Brand;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandManager _iBrandManager;
        private readonly IMapper _iMapper;

        public BrandController(IBrandManager iBrandManager, IMapper iMapper)
        {
            _iBrandManager = iBrandManager;
            _iMapper = iMapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandViewModel>>> Index()
        {
            IEnumerable<BrandViewModel> getAllBrands = _iMapper.Map<IEnumerable<BrandViewModel>>
                                                            (await _iBrandManager.GetAll());
            return View(getAllBrands);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandViewModel createBrandViewModel)
        {
            if (ModelState.IsValid)
            {
                Brand createBrand = _iMapper.Map<Brand>(createBrandViewModel);
                bool isAdd = await _iBrandManager.Create(createBrand);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Save Brand";
            }

            return View(createBrandViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<UpdateBrandViewModel>> Update(int? id)
        {
            if (id == null)
                return NotFound();

            UpdateBrandViewModel existBrand = _iMapper.Map<UpdateBrandViewModel>
                                            (await _iBrandManager.GetById(id));

            if (existBrand == null)
                return NotFound();

            return View(existBrand);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandViewModel updateBrandViewModel)
        {
            if (ModelState.IsValid)
            {
                Brand updateBrand = _iMapper.Map<Brand>(updateBrandViewModel);
                bool isAdd = await _iBrandManager.Update(updateBrand);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Update Brand";
            }

            return View(updateBrandViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                return NotFound();

            Brand existBrand = await _iBrandManager.GetById(id);

            if (existBrand == null)
                return NotFound();

            bool remove = await _iBrandManager.Remove(existBrand);

            if (remove)
                return RedirectToAction("Index");

            return BadRequest();
        }
    }
}

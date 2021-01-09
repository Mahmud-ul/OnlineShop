using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using EcommerceApp.ViewModel.SlideShow;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class SlideShowController : Controller
    {
        private readonly ISlideShowManager _iSlideShowManager;
        private readonly IMapper _iMapper;
        [Obsolete]
        private readonly IHostingEnvironment _iHostingEnvironment;

        [Obsolete]
        public SlideShowController(ISlideShowManager iSlideShowManager, IMapper iMapper, IHostingEnvironment iHostingEnvironment)
        {
            _iSlideShowManager = iSlideShowManager;
            _iMapper = iMapper;
            _iHostingEnvironment = iHostingEnvironment;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SlideShowViewModel>>> Index()
        {
            IEnumerable<SlideShowViewModel>getAllSlideShow = _iMapper.Map<IEnumerable<SlideShowViewModel>>
                (await _iSlideShowManager.GetAll());
            return View(getAllSlideShow);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Create(SlideShowViewModel slideShowViewModel, IFormFile photo)
        {
            if(ModelState.IsValid)
            {
                if( photo !=null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                        + "/slide_show", Path.GetFileName(photo.FileName));
                    await photo.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));
                    slideShowViewModel.Photo = "slide_show/" + photo.FileName;
                }

                if(photo == null)
                    slideShowViewModel.Photo = "slide_show/NoImageFound.jpg";

                SlideShow createSlideShow = _iMapper.Map<SlideShow>(slideShowViewModel);
                bool isAdd = await _iSlideShowManager.Create(createSlideShow);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Save Slide-Show";
            }
            return View(slideShowViewModel);
        }

        [HttpGet]
        public async Task<ActionResult<SlideShowViewModel>> Update(int? id)
        {
            if (id == null)
                return NotFound();
            SlideShowViewModel existSlideShow = _iMapper.Map<SlideShowViewModel>
                                            (await _iSlideShowManager.GetById(id));

            if (existSlideShow == null)
                return NotFound();
            return View(existSlideShow);
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Update(SlideShowViewModel slideShowViewModel, IFormFile photo, string pto)
        {
            if(ModelState.IsValid)
            {
                if(photo != null)
                {
                    string nameAndPath = Path.Combine(_iHostingEnvironment.WebRootPath
                        + "/slide_show", Path.GetFileName(photo.FileName));

                    await photo.CopyToAsync(new FileStream(nameAndPath, FileMode.Create));

                    slideShowViewModel.Photo = "slide_show/" + photo.FileName;
                }
                if (photo == null)
                    slideShowViewModel.Photo = pto;

                SlideShow updateSlideShow = _iMapper.Map<SlideShow>(slideShowViewModel);
                bool isAdd = await _iSlideShowManager.Update(updateSlideShow);

                if (isAdd)
                    return RedirectToAction("Index");
                else
                    ViewBag.ErrorMessage = "Failed to Update Slide-Show";
            }
            return View(slideShowViewModel);
        }

        [HttpGet]
        [Obsolete]
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
                return NotFound();
            SlideShow existSlideShow = await _iSlideShowManager.GetById(id);

            if (existSlideShow == null)
                NotFound();
            
            if (existSlideShow.Photo != "slide_show/NoImageFound.jpg")
            {
                var PhotoName = existSlideShow.Photo;
                var fullPath = Path.Combine(_iHostingEnvironment.WebRootPath + "/" + PhotoName);
                FileInfo fi = new FileInfo(fullPath);
                if (fi != null)
                {
                    System.IO.File.Delete(fullPath);
                    fi.Delete();
                }
            }
            bool remove = await _iSlideShowManager.Remove(existSlideShow);
            if (remove)
                return RedirectToAction("Index");
  
            return BadRequest();
        }
    }
} 

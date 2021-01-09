using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.ViewComponents
{
    public class SlideShowViewComponent : ViewComponent
    {
        private readonly ISlideShowManager _iSlideShowManager;
        public SlideShowViewComponent(ISlideShowManager iSlideShowManager)
        {
            _iSlideShowManager = iSlideShowManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<SlideShow> slideShows = await _iSlideShowManager.GetAll();
            slideShows = slideShows.Where(sh => sh.Status == true).ToList();
            return View(slideShows);
        }
    }
}

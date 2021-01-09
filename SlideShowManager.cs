using System;
using System.Collections.Generic;
using System.Text;
using EcommerceApp.Manager.Base;
using EcommerceApp.Manager.Contract;
using EcommerceApp.Model.Models;
using EcommerceApp.Repository.Contract;

namespace EcommerceApp.Manager
{
    public class SlideShowManager : BaseManager<SlideShow> , ISlideShowManager 
    {
        private readonly ISlideShowRepository _iSlideShowRepository;

        public SlideShowManager(ISlideShowRepository iSlideShowRepository) : base(iSlideShowRepository)
        {
            _iSlideShowRepository = iSlideShowRepository;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {           
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sspAssignment3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult nurseDetails()
        {
            return View();
        }

        public ViewResult createdPage()
        {
            return View("Create");
        }

        public ViewResult submitForm()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sspAssignment3.Models;
using sspAssignment3.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace sspAssignment3.Controllers
{
    public class HomeController : Controller
    {
        //Necessary injections for our website to work
        private INurseRepository repo;
        private readonly IWebHostEnvironment host;

        public HomeController(INurseRepository repo, IWebHostEnvironment host)
        {
            this.repo = repo;
            this.host = host;
        }

        public ActionResult Index()
        {
            IEnumerable<Nurse> nurses = repo.ShowAllNurses();
            return View(nurses);
        }

        public ActionResult nurseDetails(int ID)
        {
            Nurse nurse = repo.GetNurse(ID);
            return View(nurse);
        }

        public ActionResult createdPage()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult submitForm(NCVM n)
        {
            if(ModelState.IsValid)
            {
                string UFN = null; if (n.Photo != null)
                {
                    string uploadsFolder = Path.Combine(host.WebRootPath, "images"); 
                    UFN = Guid.NewGuid().ToString() + "_" + n.Photo.FileName; 
                    string filePath = Path.Combine(uploadsFolder, UFN);
                    n.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }


                Nurse newNurse = new Nurse()
                {
                    Name = n.Name,
                    Email = n.Email,
                    Section = n.Section,
                    Photo = UFN
                };

                repo.AddNurse(newNurse);
                return RedirectToAction("NurseDetails", new { newNurse.ID });
            }
            return View("Create");
        }
    }
}

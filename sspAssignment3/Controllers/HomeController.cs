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

        //This method is used to take the user to the Create page
        public ActionResult createdPage()
        {
            return View("Create");
        }

        //This method does the actual Nurse creation
        [HttpPost]
        public ActionResult submitForm(NCVM n)
        {
            //Only carry out Nurse creation if there are no errors
            if(ModelState.IsValid)
            {

                //Only upload a photo to the server if the user attached one.
                string UFN = null; 
                if (n.Photo != null)
                {
                    //Getting the physical path for the images folder within wwwroot
                    string uploadsFolder = Path.Combine(host.WebRootPath, "images");

                    //Giving the photo a GUID to ensure that users uploading the same photo does not lead to accidental overwriting.
                    UFN = Guid.NewGuid().ToString() + "_" + n.Photo.FileName;
                    
                    //Combining file name and folder
                    string filePath = Path.Combine(uploadsFolder, UFN);

                    //Copying the photo from device to server (upload)
                    n.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                //Nurse object creation
                Nurse newNurse = new Nurse()
                {
                    Name = n.Name,
                    Email = n.Email,
                    Section = n.Section,
                    Photo = UFN
                };

                //Adding said Nurse object to the database
                repo.AddNurse(newNurse);

                //Display the created Nurse's details by redirecting to the NurseDetails action method
                return RedirectToAction("NurseDetails", new { newNurse.ID });
            }

            return View("Create");
        }
    }
}

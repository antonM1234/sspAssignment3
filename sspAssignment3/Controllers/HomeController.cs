using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sspAssignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sspAssignment3.Controllers
{
    public class HomeController : Controller
    {
        private INurseRepository repo;

        public HomeController(INurseRepository repository)
        {
            repo = repository;
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
        public ActionResult submitForm(Nurse n)
        {
            if(ModelState.IsValid)
            {
                Nurse newNurse = new Nurse()
                {
                    Name = n.Name,
                    Email = n.Email,
                    Section = n.Section
                };
                repo.AddNurse(newNurse);
                return RedirectToAction("NurseDetails", new { newNurse.ID });
            }
            return View("Create");
        }
    }
}

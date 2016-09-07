using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task3_ViewEngine.Models;
using Task3_ViewEngine.Repository;
using System.IO;

namespace Task3_ViewEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository userRepository;

        public HomeController()
        {
            userRepository = UserRepository.Instance;
        }

        // GET: Home
        public ActionResult Person(int id)
        {
            return View(userRepository.Persons.FirstOrDefault(e => e.Id == id));
        }

        [ChildActionOnly]
        public ActionResult HeaderPerson(Person person)
        {
            return PartialView("HeaderPerson", person);
        }

        [HttpGet]
        public ActionResult PersonsList()
        {
            return View(userRepository.Persons);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Change(int id)
        {
            var person = userRepository.Persons.FirstOrDefault(e => e.Id == id);
            SwitchSide(person, true);
            if (Request.IsAjaxRequest())
            {
                return HeaderPerson(person);
            }
            return RedirectToAction("Person", new { id = id });
        }

        [NonAction]
        private void SwitchSide(Person person, bool side)
        {
            person.Faction = side;
            person.Icon = System.IO.File.ReadAllBytes(person.Faction ? Server.MapPath("~/Content/dark.png") : Server.MapPath("~/Content/white.jpg"));
            person.FactionName = person.Faction ? "Dark side" : "White side";
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = userRepository.Create(person);
                    person.Id = id;
                    SwitchSide(person, person.Faction);
                    return RedirectToAction("Person", new { id = id });
                }
            }
            catch
            {

            }
            return View();
        }
    }
}
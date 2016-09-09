using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Day3_WebApplication.Models;
using Day3_WebApplication.Repository;
using System.IO;

namespace Day3_WebApplication.Controllers
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
            return View(userRepository.GetById(id));
        }

        [ChildActionOnly]
        public ActionResult HeaderPerson(int id)
        {
            return PartialView("HeaderPerson", userRepository.GetById(id));
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
            var person = userRepository.GetById(id);
            SwitchSide(person, true);
            return Request.IsAjaxRequest() ? HeaderPerson(id) : RedirectToAction("Person", new { id });
        }

        [NonAction]
        private void SwitchSide(Person person, bool side)
        {
            var changedPerson = new Person
            {
                Id = person.Id,
                Faction = side
            };
            changedPerson.Icon =
                System.IO.File.ReadAllBytes(changedPerson.Faction
                    ? Server.MapPath("~/Content/dark.png")
                    : Server.MapPath("~/Content/white.jpg"));
            changedPerson.FactionName = changedPerson.Faction ? "Dark side" : "White side";
            changedPerson.Name = person.Name;
            userRepository.Edit(changedPerson);
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(Person person)
        {
            if (!ModelState.IsValid) return View();
            var id = userRepository.Create(person);
            SwitchSide(person, person.Faction);
            return RedirectToAction("Person", new { id });
        }
    }
}
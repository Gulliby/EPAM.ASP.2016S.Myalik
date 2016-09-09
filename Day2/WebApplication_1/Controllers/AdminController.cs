using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Infrastructure;
using WebApplication.Models;
using WebApplication.Repository;

namespace WebApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserRepository userRepository;

        public AdminController()
        {
            this.userRepository = UserRepository.Instance;
            ActionInvoker = new CustomActionInvoker();
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            return View(userRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (!ModelState.IsValid) return Index(user.Id);
            userRepository.Edit(user);
            return RedirectToAction("Index", "Home");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Repository;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository userRepository;
        
        public UserController()
        {
            this.userRepository = UserRepository.Instance;
        }

        [HttpGet]
        [ActionName("Add-User")]
        public ActionResult AddUser()
        {
            return View("AddUser");
        }

        [HttpPost]
        [ActionName("Add-User")]
        public ActionResult AddUserPost(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.Create(user);
            }
            return View("UserList",userRepository.Users);
        }

        [HttpGet]
        [ActionName("User-List")]
        public ActionResult UserListGet()
        {
            return View("UserList", userRepository.Users);
        }

        [HttpPost]
        [ActionName("User-List")]
        public ActionResult UserListPost()
        {
            return Json(null);
        }

    }
}
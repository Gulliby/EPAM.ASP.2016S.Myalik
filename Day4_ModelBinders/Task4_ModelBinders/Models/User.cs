using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task4_ModelBinders.Infrastructure;

namespace Task4_ModelBinders.Models
{
    [ModelBinder(typeof(UserModelBinder))]
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Role Role { get; set; }

        public Address Address { get; set; }
    }
}
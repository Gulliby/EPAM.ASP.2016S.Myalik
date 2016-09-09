using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task4_ModelBinders.Infrastructure;

namespace Task4_ModelBinders.Models
{
    [ModelBinder(typeof(AddressModelBinder))]
    public class Address
    {
        public string City { get; set; }

        public string Country { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string PostalCode { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Summary { get; set; }
    }
}
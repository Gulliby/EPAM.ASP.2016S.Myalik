using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task4_ModelBinders.Models;

namespace Task4_ModelBinders.Infrastructure
{
    public class AddressModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var address = bindingContext.Model as Address ?? new Address();
            address.City = GetValue(bindingContext, "City");
            address.Country = GetValue(bindingContext, "Country");
            address.Line1 = GetValue(bindingContext, "Line1");
            address.Line2 = GetValue(bindingContext, "Line2");
            address.PostalCode = GetValue(bindingContext, "PostalCode");
            address.Summary = "No Personal Address";
            if (CheckEmpty(address.PostalCode) && CheckEmpty(address.City) && CheckEmpty(address.Line1))
            {
                address.Summary = ($"{address.PostalCode} {address.City}, {address.Line1}");
            }
            return address;
        }

        private string GetValue(ModelBindingContext context, string name)
        {
            var result = context.ValueProvider.GetValue("Address." + name);
            if (result != null)
            {
                switch (name)
                {
                    case "Line2":
                        {
                            if (result == null || result.AttemptedValue == string.Empty)
                            {
                                return "not defined";
                            }
                            break;
                        }
                    case "PostalCode":
                        {
                            if (result.AttemptedValue.Length < 6)
                                return "not defined";
                            break;
                        }
                    default:
                        {
                            if (result.AttemptedValue.ToLower().Contains("po box"))
                                return "not defined";
                            break;
                        }
                }
                return result.AttemptedValue;
            }
            return null;
        }

        private bool CheckEmpty(string str)
        {
            return (!string.IsNullOrEmpty(str) && (str != "not defined"));
        }
    }
}
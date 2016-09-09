using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task4_ModelBinders.Models;

namespace Task4_ModelBinders.Infrastructure
{
    public class UserModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var user = (User)bindingContext.Model ?? new User();
            user.FirstName = GetValue(bindingContext, controllerContext, "FirstName") as string;
            user.LastName = GetValue(bindingContext, controllerContext, "LastName") as string;
            user.BirthDate = (DateTime)GetValue(bindingContext, controllerContext, "BirthDate");
            user.Role = (Role)GetValue(bindingContext, controllerContext, "Role");
            user.Address = (Address)new AddressModelBinder().BindModel(controllerContext, bindingContext);
            return user;
        }

        private object GetValue(ModelBindingContext context, ControllerContext controllerContext, string name)
        {
            //name = context.ModelName;
            var result = context.ValueProvider.GetValue(name);
            if (result != null)
            {
                switch (name)
                {
                    case "Role":
                        {
                            if (string.IsNullOrEmpty(result.AttemptedValue))
                            {
                                return Role.Guest;
                            }
                            else if (controllerContext.HttpContext.Request.IsLocal && result.AttemptedValue.ToLower() == "admin")
                            {
                                return Role.Admin;
                            }
                            else if (result.AttemptedValue.ToLower() == "user")
                                return Role.User;
                            else
                                return Role.Guest;
                        }
                    case "BirthDate":
                        {
                            return ParseDate(result.AttemptedValue);
                        }
                }

                return result.AttemptedValue;
            }
            return 0;
        }

        private DateTime ParseDate(string date)
        {
            DateTime result;
            if (!DateTime.TryParse("", CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
                DateTime.TryParseExact(date, "dd-/-MMM-/-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out result);
            return result;
        }
    }
}
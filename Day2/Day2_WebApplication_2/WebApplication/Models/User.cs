using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Interface;

namespace WebApplication.Models
{
    public class User : IEntity
    {
        
        [Key]
        [Required]
        [HiddenInput]     
        public int Id { get; set; }

        [Required]
        [Display(Name = "Login")]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Required]
        [Display(Name = "E-mail address")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
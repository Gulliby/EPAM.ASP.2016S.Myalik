using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task3_ViewEngine.Models
{
    public class Person : IEntity
    {
        [Key]
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
        [HiddenInput]
        public string FactionName { get; set; }
        public bool Faction { get; set; }
        [HiddenInput]   
        public byte[] Icon { get; set; }
    }
}
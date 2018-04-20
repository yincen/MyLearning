using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    [Table("Persons")]
    public class Person
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
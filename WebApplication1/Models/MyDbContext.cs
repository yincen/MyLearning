using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
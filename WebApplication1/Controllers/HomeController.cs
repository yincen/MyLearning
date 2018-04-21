using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Add()
        {
            var ctx = new MyDbContext();
            ctx.Persons.Add(new Person
            {
                Id = 1,
                Name = "zyc"
            });
            ctx.Books.Add(new Book
            {
                Id = 1,
                Title = "软件工程",
                PersonId = 1
            });
            ctx.Books.Add(new Book
            {
                Id = 2,
                Title = "C#指南",
                PersonId = 1
            });
            ctx.SaveChanges();
            return new ContentResult
            {
                Content = "ss"
            };
        }

        public ActionResult Get()
        {
            var ctx = new MyDbContext();
            var person = ctx.Persons.FirstOrDefault();
            return View(person);
        }
    }
}
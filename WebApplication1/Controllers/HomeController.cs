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
            if (person == null)
            {
                return new ContentResult();
            }
            return new ContentResult
            {
                Content = person.Id.ToString()
            };
        }
    }
}
using DonAR.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DonAR.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            //InitRepo.Setup();


            return View(new IndexModels());
        }

        public ActionResult ByCategory(int categoryId)
        {
            return View("Index", new IndexModels(categoryId));
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
    }
    //public class InitRepo
    //{
    //    public static void Setup()
    //    {
    //        var x = GlobalRepo.CurrentRepo();

    //        for (var i = 0; i < 20; i++)
    //        {
    //            x.Persist(new Category
    //            {
    //                Name = string.Format("Category Name {0}", i),
    //                Description = string.Format("Category Description {0}", i)
    //            });
    //        }

    //        for (var i = 0; i < 20; i++)
    //        {
    //            x.Persist(new Campaign
    //            {
    //                Title = string.Format("Título de Campaña {0}", i),
    //                Description = string.Format("Descripción de la campaña {0}", i),
    //                Category = GlobalRepo.CurrentRepo().GetAll<Category>().First(),
    //            });
    //        }

    //    }
    //}
}
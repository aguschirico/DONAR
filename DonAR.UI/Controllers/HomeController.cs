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
        public ActionResult Index(int? page)
        {
            
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            int pageSize = 2;
            int pageNumber = page ?? 1; 
            var model = new IndexModels(pageNumber, pageSize);

            return View(model);
        }

        public ActionResult ByCategory(int categoryId)
        {
            return View("Index", new IndexModels(categoryId, null, null));
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
}
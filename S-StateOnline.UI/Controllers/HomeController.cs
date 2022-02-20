using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S_StateOnline.Core.Contracts;
using S_StateOnline.Core.Models;
using S_StateOnline.Core.ViewModels;

namespace S_StateOnline.UI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategoryy> productCategories;
        public HomeController(IRepository<Product> productContext, IRepository<ProductCategoryy> categoryContext)
        {
            context = productContext;
            productCategories = categoryContext;
        }
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
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
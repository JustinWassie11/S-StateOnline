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
        public ActionResult Index(string Category = null)
        {
            List<Product> products;
            List<ProductCategoryy> categories = productCategories.Collection().ToList();
            if (Category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p => p.Category == Category).ToList();
            }

            ProductListVM model = new ProductListVM();
            model.Products = products;
            model.ProductCategories = categories;
            return View(model);
        }

        public ActionResult Details(string Id)
        {
            Product product = context.Find(Id);
            if(product == null) 
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
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
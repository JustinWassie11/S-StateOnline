using S_StateOnline.Core.Contracts;
using S_StateOnline.Core.Models;
using S_StateOnline.DataAccess.Inmemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S_StateOnline.UI.Controllers
{
    public class CategoryController : Controller
    {
        IRepository<ProductCategoryy> context;
        public CategoryController(IRepository<ProductCategoryy> categoryContext)
        {
            context = categoryContext;
        }
        // GET: Category
        public ActionResult Index()
        {
            List<ProductCategoryy> productCategories = context.Collection().ToList();
            return View(productCategories);
        }
        public ActionResult Create()
        {
            ProductCategoryy productCategoryy = new ProductCategoryy();
            return View(productCategoryy);
        }
        [HttpPost]
        public ActionResult Create(ProductCategoryy productCategoryy)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategoryy);
            }
            else
            {
                context.Insert(productCategoryy);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id)
        {
            ProductCategoryy productCategoryy = context.Find(Id);
            if (productCategoryy == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryy);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCategoryy productCategoryy, string Id)
        {
            ProductCategoryy productCategoryyToEdit = context.Find(Id);
            if (productCategoryy == null)
            {
                return HttpNotFound();
            }
            else
            {
                productCategoryyToEdit.Category = productCategoryy.Category;
                context.Commit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            ProductCategoryy productCategoryToDel = context.Find(Id);
            if (productCategoryToDel == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDel);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategoryy productCategoryToDel = context.Find(Id);
            if (productCategoryToDel == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}
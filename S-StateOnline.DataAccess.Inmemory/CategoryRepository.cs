using S_StateOnline.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;


namespace S_StateOnline.DataAccess.Inmemory
{
    public class CategoryRepository 
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategoryy> productCategories;

        public CategoryRepository()
        {
            productCategories = cache["productCategories"] as
                List<ProductCategoryy>;
                    if(productCategories == null)
            {
                productCategories = new List<ProductCategoryy>();
            }
        }
        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }
        public void Insert(ProductCategoryy p)
        {
            productCategories.Add(p);
        }
        public void Update(ProductCategoryy productCategory)
        {
            ProductCategoryy productCategoryToupdate = productCategories.Find(p => p.Id == productCategory.Id);
                if(productCategoryToupdate != null)
            {
                productCategoryToupdate = productCategory;
            }
            else
            {
                throw new Exception("Category Not Found");
            }
        }
        public ProductCategoryy Find(string Id)
        {
            ProductCategoryy productCategory = productCategories.Find(p => p.Id == Id);
                if(productCategory != null)
            {
                return productCategory;
            }
            else
            {
                throw new Exception("Category Not Found");
            }
        }
        public IQueryable<ProductCategoryy> Collection()
        {
            return productCategories.AsQueryable();
        }
        public void Delete(string Id)
        {
            ProductCategoryy productCategoryToDelete = productCategories.Find(p => p.Id == Id);
            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Category Not Found");
            }
        }
    }
}

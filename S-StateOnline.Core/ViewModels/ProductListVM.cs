using S_StateOnline.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_StateOnline.Core.ViewModels
{
    public class ProductListVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductCategoryy> ProductCategories { get; set; }
    }
}

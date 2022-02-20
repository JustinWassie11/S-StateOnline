using S_StateOnline.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_StateOnline.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategoryy> ProductCategories { get; set; }

    }
}

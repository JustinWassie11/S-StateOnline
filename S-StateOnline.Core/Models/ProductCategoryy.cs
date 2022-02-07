using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_StateOnline.Core.Models
{
    public class ProductCategoryy
    {
        public string Id;
        public string Category { get; set; }
        public ProductCategoryy()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}

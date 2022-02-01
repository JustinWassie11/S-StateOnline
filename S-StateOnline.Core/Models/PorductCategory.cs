using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_StateOnline.Core.Models
{
    class PorductCategory
    {
        public string Id;
        public string Category { get; set; }
        public ProductCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}

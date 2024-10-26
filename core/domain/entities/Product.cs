using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace domain.entities
{
public class Product : BaseEntity<int>
    {
        public string name { get; set; }
        public string description { get; set; }
        public string pictureurl { get; set; }
        public decimal price { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int BrandId { get; set; }
        public ProductType ProductType { get; set; }
        public int TypeId { get; set; }
    }
}

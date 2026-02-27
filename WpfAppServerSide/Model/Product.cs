using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {

        public string ProductId { get; set; }
        public string ProductName { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }

        public string ProductImage { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }
    }
}

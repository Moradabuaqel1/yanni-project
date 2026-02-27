using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductList:List<Product>
    {

        public ProductList() { }

        public ProductList(IEnumerable<Product> list) : base(list) { }

        public List<Product> OrderByName()
        {
            if (Count > 0)
                return this.OrderBy(item => item.ProductName).ToList();
            else
                return null;
        }
    }
}

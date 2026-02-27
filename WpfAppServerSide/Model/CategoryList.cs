using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CategoryList:List<Category>
    {
        public CategoryList() { }

        public CategoryList(IEnumerable<Category> list) : base(list) { }

        public List<Category> OrderByName()
        {
            if (Count > 0)
                return this.OrderBy(item => item.CategoryName).ToList();
            else
                return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AdminList:List<Admin>
    {
        public AdminList() { }
        public AdminList(IEnumerable<Admin> list) : base(list) { }

        public List<Admin> OrderByName()
        {
            if (Count > 0)
                return this.OrderBy(item => item.AdminName).ToList();
            else
                return null;
        }
    }
}

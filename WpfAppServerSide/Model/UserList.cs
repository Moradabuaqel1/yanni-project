using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserList:List<User>
    {
        public UserList() { }
        public UserList(IEnumerable<User> list) : base(list) { }

        public List<User> OrderByUserName()
        {
            if (Count > 0)
                return this.OrderBy(item => item.UserName).ToList();
            else
                return null;
        }
    }
}

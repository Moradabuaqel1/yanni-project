using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Admin
    {
        public string AdminName { set; get; }
        public string AdminEmail { set; get; }

        public string AdminPassword { set; get; }
        public string AdminPhone { set; get; }
        public bool IsMainAdmin { set; get; }

        public string AdminGender { set; get; }
    }
}

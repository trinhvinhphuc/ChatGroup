using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Login
    {
        public string name { get; set; }
        public string password { get; set; }
        public Login(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
    }
}

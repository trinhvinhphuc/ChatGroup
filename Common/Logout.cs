using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Logout
    {
        public string username { get; set; }
        public Logout(string username)
        {
            this.username = username;
        }
    }
}

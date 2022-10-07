using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Json
    {
        public int type { get; set; }
        public string json { get; set; }

        public Json(int type, string json)
        {
            this.type = type;
            this.json = json;
        }
    }
}

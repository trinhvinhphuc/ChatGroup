using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Message
    {
        public String fromUsername { get; set; }
        public String toUsername { get; set; }
        public String message { get; set; }
        public Message(string fromUsername, string toUsername, string message)
        {
            this.fromUsername = fromUsername;
            this.toUsername = toUsername;
            this.message = message;
        }
    }
}

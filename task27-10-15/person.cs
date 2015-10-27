using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace task27_10_15
{
    public class person
    {
        public string name { get; set; }
        public string password { get; set; }

        public string email { get; set; }
        public string country { get; set; }
        public string gender { get; set; }

        public string phone { get; set; }
    }
}

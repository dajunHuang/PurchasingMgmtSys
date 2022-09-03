using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class User
    {
        public int UID { get; set; }
        public string AccountNumber { get; set; }
        public string Pwd { get; set; }
        public int UserType { get; set; }
    }
}

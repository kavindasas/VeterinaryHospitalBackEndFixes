using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Cookie
    {
        public int UserId { get; set; }
        public string RegNo { get; set; }
        public int Type { get; set; }
        public string Pass { get; set; }
        public bool isSuccess { get; set; }
    }
}

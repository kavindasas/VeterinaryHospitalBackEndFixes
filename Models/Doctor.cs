using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Doctor : User
    {
        public string Dob { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
    }
}

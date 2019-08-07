using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Owner : User
    {
        public string DogName { get; set; }
        public string DogType { get; set; }
        public int DogAge { get; set; }
        public string DogDob { get; set; }
        public string Vacination { get; set; }
        public string HRecord { get; set; }
    }
}

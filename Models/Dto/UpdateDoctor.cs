using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Dto
{
    public class UpdateDoctor
    {
        public int UserId { get; set; }
        public string Experience { get; set; }
        public string Qualification { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Dto
{
    public class ChangePassword
    {
        public int Id { get; set; }
        public string OldPass { get; set; }
        public string NewPass { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Dto
{
    public class UpdateDogInfo
    {
        public int UserId { get; set; }
        public string DogName { get; set; }
        public string Vacination { get; set; }
        public string HRecord { get; set; }
    }
}

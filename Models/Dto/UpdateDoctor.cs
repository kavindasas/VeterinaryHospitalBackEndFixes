using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Dto
{
    public class UpdateDoctor
    {
        public int UserId { get; internal set; }
        public object DogName { get; internal set; }
        public object Vacination { get; internal set; }
        public object HRecord { get; internal set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Dto
{
    public class ReminderEmail
    {
        public DateTime Date { get; set; }
        public string OwnerEmail { get; set; }
        public string Name { get; set; }
    }
}

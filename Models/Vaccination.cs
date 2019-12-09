using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Vaccination
    {
        public int? Id { get; set; }
        public int? OwnerId { get; set; }
        public int? UserId { get; set; }
        public int? LastUpdatedUserId { get; set; }
        public string Description { get; set; }
        public string OwnerName { get; set; }
        public string Email { get; set; }
        public Boolean IsEnded { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}

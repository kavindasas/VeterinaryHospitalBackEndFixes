using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Dto
{
    public class Dnt
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public string TypeDesc { get; set; }
        public string Description { get; set; }
    }
}

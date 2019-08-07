using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models.Response
{
    public class ResponseResult<T>
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public T Result { get; set; }
    }
}

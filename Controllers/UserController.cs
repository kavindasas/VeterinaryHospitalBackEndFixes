using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ResponseResult<bool> AddMessage(Message message)
        {
            ResponseResult<bool> result = new ResponseResult<bool>();
            try
            {

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("adminLogin")]
        [HttpPost]
        public ResponseResult<Cookie> AdminLogin()
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("changePassword")]
        [HttpPost]
        public ResponseResult<Cookie> ChangePassword()
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }
    }
}
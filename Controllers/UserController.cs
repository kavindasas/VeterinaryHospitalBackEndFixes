using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Models.Response;
using BackEnd.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Route("addMessage")]
        [HttpPost]
        public ResponseResult<bool> AddMessage(MessageVM message)
        {
            ResponseResult<bool> result = new ResponseResult<bool>();
            try
            {
                UserService userService = new UserService();
                result.IsSuccess = userService.AddMessage(message);
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("getMessages")]
        [HttpGet]
        public ResponseResult<List<MessageVM>> GetMessage()
        {
            ResponseResult<List<MessageVM>> result = new ResponseResult<List<MessageVM>>();
            try
            {
                UserService userService = new UserService();
                result.Result = userService.GetMessages();
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
                UserService userService = new UserService();

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
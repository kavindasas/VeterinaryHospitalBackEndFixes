using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Models.Dto;
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

        [Route("getUsers")]
        [HttpGet]
        public ResponseResult<List<User>> GetUsers()
        {
            ResponseResult<List<User>> result = new ResponseResult<List<User>>();
            try
            {
                UserService userService = new UserService();
                result.Result = userService.GetUsers();
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("searchUsers")]
        [HttpGet]
        public ResponseResult<List<User>> searchUsers([FromQuery]string Para)
        {
            ResponseResult<List<User>> result = new ResponseResult<List<User>>();
            try
            {
                UserService userService = new UserService();
                result.Result = userService.SearchUsers(Para);
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
        public ResponseResult<Cookie> AdminLogin([FromBody] Login user)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {
                UserService userService = new UserService();
                result.Result = userService.Login(user);
                if (result.Result.UserId == 0)
                {
                    result.IsSuccess = false;
                    result.Message = "Incorrect RegNo Or Password";
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("changePassword")]
        [HttpPut]
        public ResponseResult<Cookie> ChangePassword([FromBody] ChangePassword updateDoctorInfo)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            UserService uService = new UserService();
            try
            {
                result.Result = null;
                result.IsSuccess = uService.UpdatePassword(updateDoctorInfo);
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("dnt")]
        [HttpGet]
        public ResponseResult<List<Dnt>> dnt()
        {
            ResponseResult<List<Dnt>> result = new ResponseResult<List<Dnt>>();
            UserService uService = new UserService();
            try
            {
                result.IsSuccess = true;
                result.Result = uService.GetDnts();
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("addDnt")]
        [HttpPost]
        public ResponseResult<Cookie> addDnt([FromBody] Dnt dnt)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {
                UserService userService = new UserService();
                userService.AddDnt(dnt);
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("editDnt")]
        [HttpPost]
        public ResponseResult<Cookie> editDnt([FromBody] Dnt dnt)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {
                UserService userService = new UserService();
                userService.EditDnt(dnt);
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("dntTypes")]
        [HttpGet]
        public ResponseResult<List<DntType>> dntTypes()
        {
            ResponseResult<List<DntType>> result = new ResponseResult<List<DntType>>();
            UserService uService = new UserService();
            try
            {
                result.IsSuccess = true;
                result.Result = uService.GetDntTypes();
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("addDntType")]
        [HttpPost]
        public ResponseResult<Cookie> addDntType([FromBody] DntType dnt)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {
                UserService userService = new UserService();
                userService.AddDntType(dnt);
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("editDntType")]
        [HttpPost]
        public ResponseResult<Cookie> editDntType([FromBody] Dnt dnt)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {
                UserService userService = new UserService();
                userService.EditDnt(dnt);
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("deleteDntType")]
        [HttpDelete]
        public ResponseResult<Cookie> deleteDntType([FromQuery] int Id)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {
                UserService userService = new UserService();
                userService.DeleteDntTyp(Id);
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("deleteDnt")]
        [HttpDelete]
        public ResponseResult<Cookie> deleteDnt([FromQuery] int Id)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {
                UserService userService = new UserService();
                userService.DeleteDnt(Id);
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("deleteUser")]
        [HttpDelete]
        public ResponseResult<Cookie> deleteUser([FromQuery] int Id)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {
                UserService userService = new UserService();
                userService.DeleteUser(Id);
                result.IsSuccess = true;
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
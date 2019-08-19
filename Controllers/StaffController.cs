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
    public class StaffController : ControllerBase
    {
        private const string DEFAULT_ERROR = "Something Went Wrong";

        // GET api/values/5
        [HttpGet("{id}")]
        public ResponseResult<Owner> Get(int id)
        {
            ResponseResult<Owner> result = new ResponseResult<Owner>();
            try
            {
                OwnerService ownerService = new OwnerService();
                result.Result = ownerService.GetOwner(id);

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;

        }

        // POST api/values
        [Route("reg")]
        [HttpPost]
        public ResponseResult<Cookie> Reg([FromBody] Staff staff)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {
                StaffService staffService = new StaffService();
                result.Result = staffService.AddStaff(staff);

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;

        }

        [Route("login")]
        [HttpPost]
        public ResponseResult<Cookie> Login([FromBody] Login owner)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {
                OwnerService ownerService = new OwnerService();
                result.Result = ownerService.Login(owner);
                if (result.Result.UserId == 0)
                {
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

        // PUT api/values/5
        [HttpPut]
        public ResponseResult<Cookie> Put([FromBody] UpdateDogInfo updateDogInfo)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            OwnerService ownerService = new OwnerService();

            try
            {
                result.Result = null;
                result.IsSuccess = ownerService.UpdateInfo(updateDogInfo);
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        [Route("ChangePassword")]
        [HttpPut]
        public ResponseResult<Cookie> ChangePassword([FromBody] ChangePassword updateDogInfo)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            OwnerService ownerService = new OwnerService();

            try
            {
                result.Result = null;
                result.IsSuccess = ownerService.UpdatePassword(updateDogInfo);
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
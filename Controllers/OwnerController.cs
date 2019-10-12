using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Models.Dto;
using BackEnd.Models.Response;
using BackEnd.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [DisableCors]
    public class OwnerController : ControllerBase
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
        public ResponseResult<Cookie> Reg([FromBody] Owner owner)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {
                OwnerService ownerService = new OwnerService();
                result.Result = ownerService.AddOwner(owner);

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
                if(result.Result.UserId == 0)
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

        [Route("search")]
        [HttpGet]
        public ResponseResult<List<Owner>> GetMessage([FromQuery] string para)
        {
            ResponseResult<List<Owner>> result = new ResponseResult<List<Owner>>();
            try
            {
                OwnerService ownerService = new OwnerService();
                result.Result = ownerService.Search(para);
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

        [Route("searchUsers")]
        [HttpGet]
        public ResponseResult<List<Owner>> searchUsers([FromQuery]string Para)
        {
            ResponseResult<List<Owner>> result = new ResponseResult<List<Owner>>();
            try
            {
                OwnerService ownerService = new OwnerService();
                result.Result = ownerService.SearchUsers(Para);
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
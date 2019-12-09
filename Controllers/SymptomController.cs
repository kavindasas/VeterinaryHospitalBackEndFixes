using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models.Dto;
using BackEnd.Models.Response;
using BackEnd.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymptomController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ResponseResult<List<Symptoms>> Get()
        {
            ResponseResult<List<Symptoms>> result = new ResponseResult<List<Symptoms>>();
            try
            {
                SymtomsService symtomsService = new SymtomsService();
                result.Result = symtomsService.GetSymptoms();

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;

        }

        [HttpPost]
        public ResponseResult<List<String>> Get([FromBody] SymptomReq symptomReq)
        {
            ResponseResult<List<String>> result = new ResponseResult<List<String>>();
            try
            {
                SymtomsService symtomsService = new SymtomsService();
                result.Result = symtomsService.GetDiseaseBySymptomIds(symptomReq.Ids);

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

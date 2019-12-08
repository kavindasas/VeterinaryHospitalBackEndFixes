using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Models.Dto;
using BackEnd.Models.Response;
using BackEnd.Service;
using Microsoft.AspNetCore.Mvc;
using Cookie = BackEnd.Models.Cookie;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vaccinationController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ResponseResult<List<Vaccination>> Get()
        {
            ResponseResult<List<Vaccination>> result = new ResponseResult<List<Vaccination>>();
            try
            {
                VaccinationService vService = new VaccinationService();
                result.Result = vService.GetVaccinations();

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ResponseResult<List<Vaccination>> Get(int id)
        {
            ResponseResult<List<Vaccination>> result = new ResponseResult<List<Vaccination>>();
            try
            {
                VaccinationService vService = new VaccinationService();
                result.Result = vService.GetVaccinationByOwnerId(id);

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        // POST api/values
        [HttpPost]
        public ResponseResult<Cookie> Reg([FromBody] Vaccination owner)
        {
            ResponseResult<Cookie> result = new ResponseResult<Cookie>();
            try
            {
                VaccinationService vService = new VaccinationService();
                result.IsSuccess = vService.AddVaccinations(owner);

            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;

        }

        // POST api/values
        [Route("sendemail")]
        [HttpPost]
        public void Post([FromBody] ReminderEmail value)
        {
            //SmtpClient client = new SmtpClient("mysmtpserver");
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("email@gmail.com", "password");
                // send the email
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("whoever@me.com");
                mailMessage.To.Add(value.OwnerEmail);
                mailMessage.Body = "body";
                mailMessage.Subject = "subject";
                smtp.Send(mailMessage);
            }
            // client.UseDefaultCredentials = false;
            // client.Credentials = new NetworkCredential("username", "password");

        }

        // PUT api/values/5
        [HttpPut]
        public ResponseResult<Models.Cookie> Put([FromBody] Vaccination vaccination)
        {
            ResponseResult<Models.Cookie> result = new ResponseResult<Models.Cookie>();
            VaccinationService vService = new VaccinationService();

            try
            {
                result.Result = null;
                result.IsSuccess = vService.UpdateVaccination(vaccination);
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
            return result;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

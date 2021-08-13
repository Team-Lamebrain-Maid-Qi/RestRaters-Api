
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatersOfTheLostBusiness.Data;
using RatersOfTheLostBusiness.Models.DTOs;
using RatersOfTheLostBusiness.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;


namespace Lab12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessSmsController : TwilioController
    {
        private readonly BusinessDbContext _context;
        private readonly IBusiness _business;
        //private readonly object hotel;

        public BusinessSmsController(IBusiness b, BusinessDbContext c)
        {
            //set context to the private context created above
            _business = b;
            _context = c;
        }

        //TESTER CODE: CAN I SEND YOU A TEXT?
        [HttpGet("api/sms/")]
        public ActionResult SendSms()
        {
            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            //TODO IN FUTURE: ADD TOKENS/PHONE NUMBERS TO GITIGNORE


            //UPDATED
            string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

            //IF THE ABOVE DOESN'T WORK:
            //string accountSid = "TWILIO #";
            //string authToken = "TWILIO #";

            //PHONE NUMBERS
            var miriam = new Twilio.Types.PhoneNumber("+12064033272");
            var twilio = new Twilio.Types.PhoneNumber("+12062223455");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "RUN, the robots are coming!",
                from: twilio,
                to: miriam
            );
            return Content(message.Sid);
        }


        [HttpPost("api/response/")]
        public async Task<TwiMLResult> ReceiveSms()
        {

            var responseToUser = new MessagingResponse();

            //Request.Form["Body"] is where what the user texted us goes.
            //Set it to userInput
            var userInput = Request.Form["Body"].ToString();


            //Call the GetBusinessbyNameMethod from HotelController
            //pass in userInput(Ideally a correctly spelled hotel name)
            BusinessSmsDto business = await _business.GetBusinessByName(userInput);


            //if the userInput matches the business name in the database
            if (userInput == business.Name)
            {
                //return the corresponding name, address and rating
                responseToUser.Message($"{business.Name} is located at {business.Address} and you can reach them at: {business.Phone}");
            }

            return TwiML(responseToUser);
        }



        //STUFF FROM THE INTERNET THAT WORKS
        //[HttpPost("api/response/")]
        //public TwiMLResult ReceiveSms()
        //{
        //    var messagingResponse = new MessagingResponse();

        //    var requestBody = Request.Form["Body"].ToString();

        //    if (requestBody == "hello")
        //    {
        //        messagingResponse.Message("Hi!");
        //    }
        //    else if (requestBody == "bye")
        //    {
        //        messagingResponse.Message("Goodbye");
        //    }

        //    return TwiML(messagingResponse);
        //}

        //get user text and use to do a query
    }
}


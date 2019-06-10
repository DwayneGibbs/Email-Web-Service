using SMTPapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMTPapi.Controllers
{
    public class SendEmailController : ApiController
    {
        // POST api/<controller>
        public void Post([FromBody]EmailMessageDto emailMessageDto)
        {
            Services.SendUsingGMAIL normalEmail = new Services.SendUsingGMAIL();
            normalEmail.SendMail(emailMessageDto.Application, "Normal", emailMessageDto.HtmlBody);
        }
    }
}

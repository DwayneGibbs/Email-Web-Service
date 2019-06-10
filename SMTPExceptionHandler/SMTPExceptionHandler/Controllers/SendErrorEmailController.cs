using SMTPapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMTPapi.Controllers
{
    public class SendErrorEmailController : ApiController
    {
        // POST api/<controller>
        public void Post([FromBody]EmailMessageDto emailMessageDto)
        {
            Services.SendUsingGMAIL errorEmail = new Services.SendUsingGMAIL();
            errorEmail.SendMail("High", emailMessageDto.HtmlBody);
        }
    }
}

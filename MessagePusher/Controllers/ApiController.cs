using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagePusher.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessagePusher.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Get(Message messageForSend)
        {
            if (string.IsNullOrEmpty(messageForSend.AppToken) || string.IsNullOrEmpty(messageForSend.UserKey))
            {
                return BadRequest();
            }
            if (messageForSend.AppToken.Length < 10 || messageForSend.UserKey.Length < 10)
            {
                return BadRequest();
            }
            await messageForSend.SendMessage();
            return Ok(messageForSend);
        }
    }
}

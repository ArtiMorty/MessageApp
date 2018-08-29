using System.Linq;
using MessageApp.Models.Controllers;
using MessageService;
using MessageService.db;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Controllers
{
    [Route("message/[action]")]
    public class MessageController : Controller
    {
        public MessageController(MessagesSrvc msgService)
        {
            _service = msgService;
        }

        private readonly MessagesSrvc _service;

        public IActionResult Send([FromBody]ClientsMessage message)
        {
            if (ModelState.IsValid)
            {
                var msg = new Message
                {
                    Subject = message.Subject,
                    Body = message.Body,
                    Recipients = message.Recipients
                        .Select(x => new Recipient { Name = x }).ToList()
                };

                _service.SendMessage(msg);

                return Ok(msg.Id);
            }
            else
            {
                var errors = ModelState
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray();

                return BadRequest(errors);
            }
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MessageApp.Common;

namespace MessageApp.Models.Controllers
{
    public class ClientsMessage
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        [RecipientsRequired]
        [RecipientsNotEmpty]
        public IEnumerable<string> Recipients { get; set; }
    }
}

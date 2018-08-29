using System;
using System.Threading.Tasks;
using MessageService.db;
using MessageService.Model;
using Microsoft.EntityFrameworkCore;

namespace MessageService
{
    public class MessagesSrvc : IDisposable
    {
        public MessagesSrvc()
        {
            var options = new DbContextOptionsBuilder<MessagesDbContext>()
                .UseInMemoryDatabase(databaseName: "messages_db")
                .Options;
            _context = new MessagesDbContext(options);
        }

        private readonly MessagesDbContext _context;


        public void SendMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();

            SendMessageAsync(message);
        }

        private async void SendMessageAsync(Message msg)
        {
            await Task.Run(() =>
            {
                foreach (var recipient in msg.Recipients)
                {
                    var sentMsg = new SentMessage
                    {
                        Recipient = recipient.Name,
                        Body = msg.Body
                    };

                    Console.WriteLine($"message sent to {sentMsg.Recipient}");
                }
            });
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

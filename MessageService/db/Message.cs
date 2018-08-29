using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageService.db
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public MessageConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.Recipients)
                .WithOne(x => x.Message)
                .HasForeignKey(x => x.MessageId);
        }
    }

    public class Message
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsSent { get; set; }

        public IList<Recipient> Recipients { get; set; }
    }
}

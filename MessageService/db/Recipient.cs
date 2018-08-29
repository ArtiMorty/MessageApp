using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessageService.db
{
    public class RecepientConfiguration : IEntityTypeConfiguration<Recipient>
    {
        public void Configure(EntityTypeBuilder<Recipient> builder)
        {
            builder.ToTable("Recepients");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Message)
                .WithMany(x => x.Recipients)
                .HasForeignKey(x => x.MessageId);
        }
    }

    public class Recipient
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public string Name { get; set; }

        public Message Message { get; set; }
    }
}

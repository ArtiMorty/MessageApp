using Microsoft.EntityFrameworkCore;

namespace MessageService.db
{
    internal class MessagesDbContext : DbContext
    {
        public MessagesDbContext(DbContextOptions<MessagesDbContext> options) : base(options)
        {

        }

        public DbSet<Message>  Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new RecepientConfiguration());
        }
    }
}

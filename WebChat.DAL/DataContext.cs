using Microsoft.EntityFrameworkCore;
using WebChat.DAL.Entities;

namespace WebChat.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatAction> ChatActions { get; set; }
        public DbSet<ChatUser> ChatUser { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}

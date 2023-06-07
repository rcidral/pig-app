using Microsoft.EntityFrameworkCore;
using Models;

namespace Database
{
    public class Context : DbContext
    {
        public string connection = "Server=localhost;User Id=root;Database=pig_app";
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql(connection, ServerVersion.AutoDetect(connection));
    }
}
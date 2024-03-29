using Microsoft.EntityFrameworkCore;
using Models;

namespace Database
{
    public class Context : DbContext
    {
        public string connection = "Server=localhost;User Id=root;Password=Wheniparkmyrr_1234;Database=pig_app_";
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Clean> Cleans { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql(connection, ServerVersion.AutoDetect(connection));
    }
}


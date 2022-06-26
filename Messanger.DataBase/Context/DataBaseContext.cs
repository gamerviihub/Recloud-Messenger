using Messanger.Server.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace Messanger.Server.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<UserStatuses>? UserStatuses { get; set; }


        public DataBaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Filename=DataBase.db");
        }
    }
}

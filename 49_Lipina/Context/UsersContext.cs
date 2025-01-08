    using Microsoft.EntityFrameworkCore;
using _49_Lipina.Models;
using System;

namespace _49_Lipina.Context
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public UsersContext()
        {
            Database.EnsureCreated();
            Users.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;" +
                "uid=root;" +
                "port=3303;" +
                "pwd=;" +
                "database=RestApi", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}

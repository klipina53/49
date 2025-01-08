using Microsoft.EntityFrameworkCore;
using _49_Lipina.Models;
using System;

namespace _49_Lipina.Context
{
    public class DishesContext : DbContext
    {
        public DbSet<Dishes> Dishes { get; set; }
        public DishesContext()
        {
            Database.EnsureCreated();
            Dishes.Load();
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

﻿using Microsoft.EntityFrameworkCore;
using _49_Lipina.Models;
using System;

namespace _49_Lipina.Context
{
    public class VersionsContext : DbContext
    {
        public DbSet<Versions> Versions { get; set; }
        public VersionsContext()
        {
            Database.EnsureCreated();
            Versions.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;" +
                "uid=root;" +
                "port=3306;" +
                "pwd=;" +
                "database=RestApi", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}

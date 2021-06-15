using Microsoft.EntityFrameworkCore;
using MoviesApp.Entities;
using System;

namespace MoviesApp.DataAccess
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
             optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS01;Database=MoviesDb;Trusted_Connection=True;Connect TimeOut=30;MultipleActiveResultSets=True;");
        }

    }
}

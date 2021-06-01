using Microsoft.EntityFrameworkCore;
using MovieProject.Core.Models;
using MovieProject.Data.Configurations;
using MovieProject.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) // Veritabanında tablolar oluşmadan önce çalışacak olan metot.
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CinemaConfiguration());

            modelBuilder.ApplyConfiguration(new MovieSeed(new int[] { 1, 2, 3, 4, 5, 6 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2, 3, 4 }));
            modelBuilder.ApplyConfiguration(new CinemaSeed(new int[] { 1, 2 }));
        }
    }
}

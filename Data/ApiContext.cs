using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Proxies;
using System;
using worknet_api.Models;
using worknet_api.Helpers;

namespace worknet_api.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies(true);
        //    base.OnConfiguring(optionsBuilder);
        //}


    }
}

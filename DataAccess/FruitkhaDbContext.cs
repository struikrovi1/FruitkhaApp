using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FruitkhaDbContext : IdentityDbContext<MyUser>
    {
        public FruitkhaDbContext(DbContextOptions<FruitkhaDbContext> options)
          : base(options)
        {

        }

        public DbSet<MyUser> MyUsers { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories{ get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Countdown> Countdowns { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<MyUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
        }




    }
}

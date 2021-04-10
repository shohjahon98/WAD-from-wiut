using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Test2.Models;

namespace Test2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Groups> MyGroups { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Genres> Janrs { get; set; }


    }
}

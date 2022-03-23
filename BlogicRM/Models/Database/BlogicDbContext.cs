using BlogicRM.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogicRM.Models.Database
{
    public class BlogicDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Consultant> Consultants { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public BlogicDbContext(DbContextOptions options) : base(options)
        { 
        }

       
    }
}

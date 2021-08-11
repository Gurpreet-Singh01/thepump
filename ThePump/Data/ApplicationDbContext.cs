using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ThePump.Models;

namespace ThePump.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //declare the Goal model so the db can work with it and so can the rest of our app
        public DbSet<Goal> Goal { get; set; }
        public DbSet<ThePump.Models.AddData> AddData { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

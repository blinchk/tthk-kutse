using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using KutseApp.Models;

namespace KutseApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<KutseApp.Models.Guest> Guest { get; set; }
        public DbSet<KutseApp.Models.Event> Event { get; set; }
    }
}

using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcoU.Models
{
    public class ProjectContext : IdentityDbContext<User>
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<CleaningPlan> CleaningPlans { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}

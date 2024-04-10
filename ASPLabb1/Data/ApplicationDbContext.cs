using ASPLabb1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPLabb1.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    // Create public virtual DbSet of your database tables (models) below
    public DbSet<Personal> Personals { get; set; }
    public DbSet<TimeOffApplication> TimeOffApplications { get; set; }
    public DbSet<History> Historys { get; set; }
}
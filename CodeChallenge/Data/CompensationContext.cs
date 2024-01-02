using CodeChallenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CodeChallenge.Data
{
    // Added by nborden88 12/29/2023
    public class CompensationContext : DbContext
    {
        public CompensationContext(DbContextOptions<CompensationContext> options) : base(options)
        {

        }

        public DbSet<Compensation> Compensations { get; set; }
    }
}

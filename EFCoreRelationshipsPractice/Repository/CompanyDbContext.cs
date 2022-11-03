using EFCoreRelationshipsPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsPractice.Repository
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            : base(options)
        {
        }

        public DbSet<CompanyEntity> CompanyEntities { get; set; }

        public DbSet<ProfileEntity> profileEntities { get; set; }

        public DbSet<EmployeeEntity> employeeEntities { get; set; }


        internal Task AddAsync()
        {
            throw new NotImplementedException();
        }
    }
}
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Models;
using EFCoreRelationshipsPractice.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsPractice.Services
{
    public class CompanyService
    {
        private readonly CompanyDbContext companyDbContext;

        public CompanyService(CompanyDbContext companyDbContext)
        {
            this.companyDbContext = companyDbContext;
        }

        public async Task<List<CompanyDto>> GetAll()
        {
            var companyEntitys = this.companyDbContext.CompanyEntities
                .Include(company => company.ProfileEntity)
                .Include(company => company.EmployeesEntity)
                .ToList();

            return companyEntitys.Select(c => new CompanyDto(c)).ToList();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            var findCompany = await companyDbContext.CompanyEntities
    .Include(c => c.ProfileEntity)
    .Include(c => c.EmployeesEntity)
    .FirstOrDefaultAsync(c => c.Id == id);
            return new CompanyDto(findCompany);
        }

        public async Task<int> AddCompany(CompanyDto companyDto)
        {
            CompanyEntity companyEntity = companyDto.ToEntity();
            await this.companyDbContext.CompanyEntities.AddAsync(companyEntity);
            await this.companyDbContext.SaveChangesAsync();

            return companyEntity.Id;
        }

        public async Task DeleteCompany(int id)
        {
            var findCompany = await companyDbContext.CompanyEntities
                .Include(c => c.ProfileEntity)
                .Include(c => c.EmployeesEntity)
                .FirstOrDefaultAsync(c => c.Id == id);
            companyDbContext.CompanyEntities.RemoveRange(findCompany);
            await this.companyDbContext.SaveChangesAsync();
        }
    }
}
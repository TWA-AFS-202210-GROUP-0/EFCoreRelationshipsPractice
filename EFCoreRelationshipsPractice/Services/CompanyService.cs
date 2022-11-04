using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
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
            var companies = await companyDbContext.Companies.Include(e => e.ProfileEntity).Include( e => e.EmployeeEntities).ToListAsync();

            return companies.Select(e => new CompanyDto(e)).ToList();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            var company = await companyDbContext.Companies.SingleOrDefaultAsync(e => e.Id == id);
            return new CompanyDto(company);
        }

        public async Task<int> AddCompany(CompanyDto companyDto)
        {
            //1 convert dto to entity
            var companyEntity = companyDto.ToEntity();
            //2 save entity to db
            await companyDbContext.Companies.AddAsync(companyEntity);
            await companyDbContext.SaveChangesAsync();
            return companyEntity.Id;
        }

        public async Task DeleteCompany(int id)
        {
            var company = await companyDbContext.Companies.Include(e => e.ProfileEntity).Include(e => e.EmployeeEntities).SingleOrDefaultAsync(e => e.Id == id);

            companyDbContext.Profiles.RemoveRange(company.ProfileEntity);
            companyDbContext.Employees.RemoveRange(company.EmployeeEntities);
            companyDbContext.Companies.Remove(company);

            await companyDbContext.SaveChangesAsync();

        }
    }
}
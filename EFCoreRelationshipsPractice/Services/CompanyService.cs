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
            var companies = companyDbContext.Companies
                .Include(x => x.Profile)
                .Include(x => x.Employees)
                .ToList();
            return companies.Select(x => new CompanyDto(x)).ToList();
        }

        public async Task<CompanyDto> GetById(int id)
        {
            var company = companyDbContext.Companies.FirstOrDefault(_ => _.Id == id);
            return company != null ? new CompanyDto(company) : null;
        }

        public async Task<int> AddCompany(CompanyDto companyDto)
        {
            // 1. cover DTO to entity
            CompanyEntity companyEntity = companyDto.ToEntity();

            // 2. Save entity to DB
            companyDbContext.Companies.Add(companyEntity);
            await companyDbContext.SaveChangesAsync();

            // 3. return company ID
            return companyEntity.Id;
        }

        public async Task DeleteCompany(int id)
        {
            var company = companyDbContext.Companies
                .Include(_ => _.Profile)
                .Include(_ => _.Employees)
                .FirstOrDefault(_ => _.Id == id);
            companyDbContext.Companies.RemoveRange(company);
            await companyDbContext.SaveChangesAsync();
        }
    }
}
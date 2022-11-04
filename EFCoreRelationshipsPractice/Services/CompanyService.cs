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
                .Include(company => company.Profile)
                .Include(company => company.Employees)
                .ToList();
            return companies.Select(companyEntity => new CompanyDto(companyEntity)).ToList();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            var foundCompany = companyDbContext.Companies
                .Include(company => company.Employees)
                .Include(company => company.Profile)
                .FirstOrDefault(company => company.Id == id);
            return new CompanyDto(foundCompany);
        }

        public async Task<int> AddCompany(CompanyDto companyDto)
        {
            var companyEntity = companyDto.ToEntity();
            await companyDbContext.Companies.AddAsync(companyEntity);
            await companyDbContext.SaveChangesAsync();
            return companyEntity.Id;
        }

        public async Task DeleteCompany(int id)
        {
            var foundCompany = companyDbContext.Companies
                .Include(company => company.Employees)
                .Include(company => company.Profile)
                .FirstOrDefault(company => company.Id == id);
            companyDbContext.Employees.RemoveRange(foundCompany.Employees);
            companyDbContext.Companies.Remove(foundCompany);
            companyDbContext.Profiles.Remove(foundCompany.Profile);
            await companyDbContext.SaveChangesAsync();
        }
    }
}
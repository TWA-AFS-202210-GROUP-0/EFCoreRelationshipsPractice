using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
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
            // 1. get company from db
            var companies = companyDbContext.Companies.
                Include(company => company.Profile).
                Include(company => company.Employee).
                ToList();
            // 2. convert entity to the dto
            return companies.Select(cmpEntity => new CompanyDto(cmpEntity)).ToList();
        }

        public async Task<CompanyDto> GetById(long id)
        {
            var CompanyDto companyDto = companyDbContext.Companies.Find()
        }

        public async Task<int> AddCompany(CompanyDto companyDto)
        {
            //1. convert dto to entity
            CompanyEntity entity = companyDto.ToEntity();
            //2. save entity to db
            await companyDbContext.Companies.AddAsync(entity);
            await companyDbContext.SaveChangesAsync();
            //3. return company id
            return entity.Id;
        }

        public async Task DeleteCompany(int id)
        {
            
        }
    }
}
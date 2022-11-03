using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Repository;
using EFCoreRelationshipsPractice.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreRelationshipsPracticeTest.ServiceTest
{

    [Collection("Sequential1")]
    public class CompanyServiceTest : TestBase
    {
        
        public CompanyServiceTest( CustomWebApplicationFactory<Program> factory) : base(factory)
        {
            
        }

        [Fact]
        public async Task Should_create_company_via_company_service()
        {
            //Given
            var context = GetCompanyContext();
            var newCompanyDto = GenerateCompanyDto();
            var companyService = new CompanyService(context);
            //When
            await companyService.AddCompany(newCompanyDto);
            //Then
            Assert.Equal(1, context.Companies.Count());
        }

        [Fact]
        public async Task Should_delete_company_and_its_children()
        {
            //Given
            var context = GetCompanyContext();
            var newCompanyDto = GenerateCompanyDto();
            var companyService = new CompanyService(context);
            var companyId = await companyService.AddCompany(newCompanyDto);
            //When
            await companyService.DeleteCompany(companyId);
            var companies = await companyService.GetAll();
            //Then
            Assert.Equal(0, companies.Count());
        }

        [Fact]
        public async Task Should_get_company_by_id_success()
        {
            //Given
            var context = GetCompanyContext();
            var newCompanyDto = GenerateCompanyDto();
            var companyService = new CompanyService(context);
            var companyId = await companyService.AddCompany(newCompanyDto);
            //When
            var company = await companyService.GetById(companyId);
            //Then
            Assert.Equal("IBM", company.Name);
        }

        [Fact]
        public async Task Should_create_many_companies_and_Get_all()
        {
            //Given
            var context = GetCompanyContext();
            var newCompanyDto = GenerateCompanyDto();
            var newCompanyDto2 = GenerateCompanyDto();
            var companyService = new CompanyService(context);
            await companyService.AddCompany(newCompanyDto);
            await companyService.AddCompany(newCompanyDto2);
            //When
            var companies = await companyService.GetAll();
            //Then
            Assert.Equal(2,companies.Count);

        }


        private static CompanyDto GenerateCompanyDto()
        {
            var companyDto = new CompanyDto()
            {
                Name = "IBM",
                EmployeeDtos = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Tom",
                        Age = 19
                    }
                },
                ProfileDto = new ProfileDto()
                {
                    CertId = "100",
                    RegisteredCapital = 100010,
                },
            };
            return companyDto;
        }

        public CompanyDbContext GetCompanyContext()
        {
            var scope = Factory.Services.CreateScope();
            var scopedService = scope.ServiceProvider;
            CompanyDbContext context = scopedService.GetRequiredService<CompanyDbContext>();
            return context;
        }

    }
}

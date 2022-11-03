using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Repository;
using EFCoreRelationshipsPractice.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationshipsPracticeTest.ServicesTest
{
    [Collection("Sequential")]
    public class CompanyServiceTest : TestBase
    {
        public CompanyServiceTest(CustomWebApplicationFactory<Program> factory) : base(factory)
        {

        }
        [Fact]
        public async Task Should_success_when_add_company_in_db_given_company_dto_in_service()
        {
            // given
            var context=GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
                EmployeesDtos = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Tom",
                        Age = 19,
                    },
                },
                ProfileDto = new ProfileDto()
                {
                    RegisteredCapital = 100010,
                    CertId = "100",
                },
            };
            CompanyService companyService = new CompanyService(context);

            // when
            await companyService.AddCompany(companyDto);

            // then
            Assert.Equal(1,context.Companies.Count());

        }

        [Fact]
        public async Task Should_success_when_get_all_companies_dto_given_contextdb_in_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto1 = new CompanyDto
            {
                Name = "IBM",
                EmployeesDtos = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Tom",
                        Age = 19,
                    },
                },
                ProfileDto = new ProfileDto()
                {
                    RegisteredCapital = 100010,
                    CertId = "100",
                },
            };
            CompanyDto companyDto2 = new CompanyDto
            {
                Name = "SLB",
                EmployeesDtos = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Tomy",
                        Age = 22,
                    },
                },
                ProfileDto = new ProfileDto()
                {
                    RegisteredCapital = 100001,
                    CertId = "105",
                },
            };
            CompanyService companyService = new CompanyService(context);
            await companyService.AddCompany(companyDto1);
            await companyService.AddCompany(companyDto2);

            // when

            var companiesDtos = await companyService.GetAll();

            // then
            Assert.Equal(2, context.Companies.Count());
            Assert.Equal("IBM", companiesDtos[0].Name);
            Assert.Equal("SLB", companiesDtos[1].Name);
        }



        private CompanyDbContext GetCompanyDbContext()
        {
            var scope = Factory.Services.CreateScope();
            var scopedService = scope.ServiceProvider;
            CompanyDbContext context = scopedService.GetRequiredService<CompanyDbContext>();
            return context;
        }
    }
}

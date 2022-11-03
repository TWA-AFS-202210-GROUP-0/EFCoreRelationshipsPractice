using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Repository;
using EFCoreRelationshipsPractice.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRelationshipsPracticeTest.ServiceTest
{
    public class CompanyServiceTest : TestBase
    {
        public CompanyServiceTest(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_create_company_success_via_company_service()
        {
            //given
            var context = GetCompanyDbContext();
            CompanyDto companyDto  = new CompanyDto();
            companyDto.Name = "sbl";
            companyDto.Employees = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Tom",
                        Age = 19,
                    },
                };
            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };
            CompanyService companyService = new CompanyService(context);
            // when
            await companyService.AddCompany(companyDto);

            // then
            Assert.Equal(1, context.CompanyEntities.Count());
        }

        [Fact]
        public async Task Should_get_all_company_success_via_company_service()
        {
            //given
            var context = GetCompanyDbContext();
            var c1 = getCompanyDto();
            var c2 = getCompanyDto();
            CompanyService companyService = new CompanyService(context);
            await companyService.AddCompany(c1);
            await companyService.AddCompany(c2);
            // when
            var res = await companyService.GetAll();

            // then
            Assert.Equal(2, res.Count());
        }

        private CompanyDbContext GetCompanyDbContext()
        {
            var scope = Factory.Services.CreateScope();
            var scopeService  = scope.ServiceProvider;
            CompanyDbContext context = scopeService.GetRequiredService<CompanyDbContext>();
            return context;
        }

        private CompanyDto getCompanyDto()
        {
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "sbl";
            companyDto.Employees = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Tom",
                        Age = 19,
                    },
                };
            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };
            return companyDto;
        }
    }
}

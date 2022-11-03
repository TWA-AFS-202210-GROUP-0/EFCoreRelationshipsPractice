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

        private CompanyDbContext GetCompanyDbContext()
        {
            var scope = Factory.Services.CreateScope();
            var scopeService  = scope.ServiceProvider;
            CompanyDbContext context = scopeService.GetRequiredService<CompanyDbContext>();
            return context;
        }
    }
}

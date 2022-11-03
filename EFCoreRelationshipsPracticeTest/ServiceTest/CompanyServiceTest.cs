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
    [Collection("lalala")]
    public class CompanyServiceTest : TestBase
    {
        public CompanyServiceTest(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_create_company_using_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
                EmployeeDto = new List<EmployeeDto>()
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

            //then
            Assert.Equal(1, context.Companies.Count());

        }

        [Fact]
        public async Task Should_get_all_companies_using_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
                EmployeeDto = new List<EmployeeDto>()
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
                Name = "MS",
                EmployeeDto = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Jerry",
                        Age = 18,
                    },
                },
                ProfileDto = new ProfileDto()
                {
                    RegisteredCapital = 100020,
                    CertId = "101",
                },
            };
            CompanyService companyService = new CompanyService(context);
            // when
            await companyService.AddCompany(companyDto);
            await companyService.AddCompany(companyDto2);
            await companyService.GetAll();

            //then
            Assert.Equal(2, context.Companies.Count());

        }

        [Fact]
        public async Task Should_get_one_company_by_id_using_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
                EmployeeDto = new List<EmployeeDto>()
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
                Name = "MS",
                EmployeeDto = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Jerry",
                        Age = 18,
                    },
                },
                ProfileDto = new ProfileDto()
                {
                    RegisteredCapital = 100020,
                    CertId = "101",
                },
            };
            CompanyService companyService = new CompanyService(context);
            // when
            await companyService.AddCompany(companyDto);
            await companyService.AddCompany(companyDto2);
            var response = await companyService.GetById(1);

            //then
            Assert.Equal("IBM", response.Name);

        }

        [Fact]
        public async Task Should_delete_one_company_by_id_using_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
                EmployeeDto = new List<EmployeeDto>()
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
                Name = "MS",
                EmployeeDto = new List<EmployeeDto>()
                {
                    new EmployeeDto()
                    {
                        Name = "Jerry",
                        Age = 18,
                    },
                },
                ProfileDto = new ProfileDto()
                {
                    RegisteredCapital = 100020,
                    CertId = "101",
                },
            };
            CompanyService companyService = new CompanyService(context);
            // when
            var id = await companyService.AddCompany(companyDto);
            await companyService.AddCompany(companyDto2);
            await companyService.DeleteCompany(id);

            //then
            Assert.Equal(1, context.Companies.Count());

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

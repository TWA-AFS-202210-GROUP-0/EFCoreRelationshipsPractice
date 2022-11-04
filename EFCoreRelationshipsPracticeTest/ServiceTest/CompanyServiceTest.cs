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
    [Collection("1")]
    public class CompanyServiceTest : TestBase
    {
        public CompanyServiceTest(CustomWebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_create_company_success_via_company_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
            };
            // profile
            // employee
            CompanyService companyService = new CompanyService(context);

            // when
            await companyService.AddCompany(companyDto);

            // then
            Assert.Equal(1, context.Companies.Count());
        }

        [Fact]
        public async Task Should_create_company_with_profile_success_via_company_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
            };
            // profile
            companyDto.ProfileDTO = new ProfileDto
            {
                CertId = "id",
                RegisteredCapital = 1,
            };

            // employee
            CompanyService companyService = new CompanyService(context);

            // when
            await companyService.AddCompany(companyDto);

            // then
            Assert.Equal(1, context.Companies.Count());
        }

        [Fact]
        public async Task Should_create_company_with_profile_and_employee_success_via_company_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
            };
            companyDto.ProfileDTO = new ProfileDto
            {
                CertId = "id",
                RegisteredCapital = 1,
            };
            companyDto.EmployeeDTO = new List<EmployeeDto>() { new EmployeeDto { Age = 100, Name = "Yaomeng" } };

            // employee
            CompanyService companyService = new CompanyService(context);

            // when
            await companyService.AddCompany(companyDto);

            // then
            Assert.Equal(1, context.Companies.Count());
        }


        [Fact]
        public async Task Should_get_all_company_success_via_company_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
            };
            // profile
            // employee
            CompanyService companyService = new CompanyService(context);
            await companyService.AddCompany(companyDto);

            // when
            var companies = await companyService.GetAll();

            // then
            Assert.Equal(1, companies.Count());
        }

        [Fact]
        public async Task Should_get_company_by_Id_success_via_company_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
            };
            // profile
            // employee
            CompanyService companyService = new CompanyService(context);
            var id = await companyService.AddCompany(companyDto);

            // when
            var responseCompany = await companyService.GetById(id);

            // then
            Assert.Equal(responseCompany.Name, companyDto.Name);
        }

        [Fact]
        public async Task Should_delete_company_success_via_company_service()
        {
            // given
            var context = GetCompanyDbContext();
            CompanyDto companyDto = new CompanyDto
            {
                Name = "IBM",
            };
            companyDto.ProfileDTO = new ProfileDto
            {
                CertId = "id",
                RegisteredCapital = 1,
            };
            companyDto.EmployeeDTO = new List<EmployeeDto>() { new EmployeeDto { Age = 100, Name = "Yaomeng" } };
            CompanyService companyService = new CompanyService(context);
            var id = await companyService.AddCompany(companyDto);

            // when
            await companyService.DeleteCompany(id);

            // then
            var responseCompany = await companyService.GetById(id);
            Assert.Null(responseCompany);
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

using System.Collections.Generic;
using EFCoreRelationshipsPractice.Models;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        public CompanyDto()
        {
        }

        public CompanyDto(CompanyEntity companyEntity)
        {
            this.Name = companyEntity.Name;
            if (companyEntity.Profile != null)
            {
                this.ProfileDto = new ProfileDto(companyEntity.Profile);
            }

            this.EmployeeDto = companyEntity.Employee?.Select(_ => new EmployeeDto(_)).ToList();
        }
        public string Name { get; set; }

        public ProfileDto? ProfileDto { get; set; }

        public List<EmployeeDto>? EmployeeDto{ get; set; }

        public CompanyEntity ToEntity()
        {
            return new CompanyEntity()
            {
                Name = this.Name,
                Profile = ProfileDto?.ToEntity(),
                Employee = EmployeeDto?.Select(employee => employee.ToEntity()).ToList(),
                //Profile = this.ProfileDto != null ? this.ProfileDto.ToEntity() : null
            };
        }
    }
}
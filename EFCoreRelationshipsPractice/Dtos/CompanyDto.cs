using System.Collections.Generic;
using EFCoreRelationshipsPractice.Models;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        public CompanyDto(CompanyEntity companyEntity)
        {
            this.Name = companyEntity.Name;
            this.ProfileDto = companyEntity.Profile != null ? new ProfileDto(companyEntity.Profile) : null;
            this.EmployeeDtos = companyEntity.Employees?.Select(employeeEntity => new EmployeeDto(employeeEntity)).ToList();
        }

        public CompanyDto()
        {
        }

        public CompanyEntity ToEntity()
        {
            return new CompanyEntity()
            {
                Name = this.Name,
                Profile = this.ProfileDto?.ToProfileEntity(),
                //Profile = this.ProfileDto.ToProfileEntity() != null ? this.ProfileDto.ToProfileEntity() : null
                Employees = this.EmployeeDtos?.Select(employeeDto => employeeDto.ToEntity()).ToList()
            };
        }

        public string Name { get; set; }

        public ProfileDto? ProfileDto { get; set; }

        public List<EmployeeDto>? EmployeeDtos { get; set; }

    }
}
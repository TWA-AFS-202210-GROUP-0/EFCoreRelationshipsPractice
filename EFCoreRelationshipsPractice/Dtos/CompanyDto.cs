using EFCoreRelationshipsPractice.Models;
using System.Collections.Generic;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        public CompanyDto(CompanyEntity companyEntity)
        {
            this.Name = companyEntity.Name;

            if (companyEntity.ProfileEntity != null)
            {
                Profile = new ProfileDto(companyEntity.ProfileEntity);
            }

            if (companyEntity.EmployeesEntity != null)
            {
                Employees = companyEntity.EmployeesEntity.Select(e => e.toDto()).ToList();
            }
        }

        public CompanyDto(string Name)
        {
            this.Name=Name;
        }

        public CompanyDto()
        {
        }

        public CompanyEntity ToEntity()
        {
            return new CompanyEntity
            {
                Name = this.Name,
                ProfileEntity = this.Profile?.toProfileEntity(),
                EmployeesEntity = this.Employees?.Select(e => e.toEmployeeEntity()).ToList(),
            };
        }

        public string Name { get; set; }

        public ProfileDto? Profile { get; set; }

        public List<EmployeeDto>? Employees { get; set; }

    }
}
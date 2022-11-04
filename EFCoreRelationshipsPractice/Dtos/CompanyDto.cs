using EFCoreRelationshipsPractice.Repository;
using System.Collections.Generic;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        public CompanyDto()
        {
        }

        public CompanyDto(CompanyEntity companyEntity)
        {
            Name = companyEntity.Name;
            ProfileDTO = companyEntity.Profile != null ? new ProfileDto(companyEntity.Profile) : null;
            EmployeeDTO = companyEntity.Employees != null ? companyEntity.Employees.Select(x => new EmployeeDto(x)).ToList() : null;
        }

        public string Name { get; set; }

        public ProfileDto? ProfileDTO { get; set; }

        public List<EmployeeDto>? EmployeeDTO { get; set; }

        public CompanyEntity ToEntity()
        {
            var entity = new CompanyEntity();
            entity.Name = Name;
            entity.Profile = this.ProfileDTO?.ToEntity();
            entity.Employees = this.EmployeeDTO?.Select(x => x.ToEntity()).ToList();
            return entity;
        }

        public bool Equals(CompanyDto anotherDto)
        {
            return Name.Equals(anotherDto.Name) &&
                    ProfileDTO.Equals(anotherDto.ProfileDTO);
        }
    }

}
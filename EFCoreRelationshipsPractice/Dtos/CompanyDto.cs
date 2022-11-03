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
        }

        public string Name { get; set; }

        public ProfileDto? ProfileDTO { get; set; }

        public List<EmployeeDto>? Employees { get; set; }

        public CompanyEntity ToEntity()
        {
            var entity = new CompanyEntity();
            entity.Name = Name;
            entity.Profile = this.ProfileDTO?.ToEntity();
            return entity;
        }
    }

}
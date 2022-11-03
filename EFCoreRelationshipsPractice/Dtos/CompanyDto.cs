using EFCoreRelationshipsPractice.Repository;
using System.Collections.Generic;
using EFCoreRelationshipsPractice.Model;

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
            this.ProfileDto = companyEntity.ProfileEntity != null ? new ProfileDto(companyEntity.ProfileEntity) : null;
        }

        public string Name { get; set; }

        public ProfileDto? ProfileDto { get; set; }

        public List<EmployeeDto>? Employees { get; set; }

        public CompanyEntity ToEntity()
        {
            return new CompanyEntity
            {
                Name = this.Name,
                ProfileEntity = this.ProfileDto?.ToEntity(),
            };
        }

    }
}
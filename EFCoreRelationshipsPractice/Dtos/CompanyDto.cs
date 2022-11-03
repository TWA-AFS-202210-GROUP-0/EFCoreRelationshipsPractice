using EFCoreRelationshipsPractice.Model;
using System.Collections.Generic;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        private CompanyEntity companyEntity;

        public CompanyDto()
        {
        }

        public CompanyDto(CompanyEntity companyEntity)
        {
            Name = companyEntity.Name;
            ProfileDto = companyEntity.Profile != null ? new ProfileDto(companyEntity.Profile) : null;
        }

        public string Name { get; set; }

        public ProfileDto? ProfileDto { get; set; }

        public List<EmployeeDto>? Employees { get; set; }

        internal CompanyEntity ToEntity()
        {
            return new CompanyEntity()
            {
                Name = this.Name,
                Profile = this.ProfileDto != null? this.ProfileDto.ToEntity():null
            };
        }
    }
}
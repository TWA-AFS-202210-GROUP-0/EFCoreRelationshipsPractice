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
        }
        public string Name { get; set; }

        public ProfileDto? ProfileDto { get; set; }

        public List<EmployeeDto>? Employees { get; set; }

        public CompanyEntity ToEntity()
        {
            return new CompanyEntity()
            {
                Name = this.Name,
                Profile = ProfileDto?.ToEntity(),
                //Profile = this.ProfileDto != null ? this.ProfileDto.ToEntity() : null
            };
        }
    }
}
using System.Collections.Generic;
using EFCoreRelationshipsPractice.Models;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyDto
    {
        public CompanyDto(CompanyEntity companyEntity)
        {
            this.Name = companyEntity.Name;
        }

        public CompanyDto()
        {
        }

        public CompanyEntity ToEntity()
        {
            return new CompanyEntity
            {
                Name = this.Name
            };
        }

        public string Name { get; set; }

        public ProfileDto? Profile { get; set; }

        public List<EmployeeDto>? Employees { get; set; }

    }
}
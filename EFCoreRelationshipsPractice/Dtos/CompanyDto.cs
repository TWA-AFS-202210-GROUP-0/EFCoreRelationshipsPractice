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
            EmployeesDtos = companyEntity.Employees?.Select(employeeEntity => new EmployeeDto(employeeEntity)).ToList();
        }

        public string Name { get; set; }

        public ProfileDto? ProfileDto { get; set; }

        public List<EmployeeDto>? EmployeesDtos { get; set; }

        internal CompanyEntity ToEntity()
        {
            
            var companyEntity = new CompanyEntity();
            companyEntity.Name = Name;
            companyEntity.Employees = new List<EmployeeEntity>();
            companyEntity.Profile = ProfileDto != null ? ProfileDto.ToEntity() : null;
            if (EmployeesDtos != null)
            {
                foreach (EmployeeDto employeeDto in EmployeesDtos)
                {
                    companyEntity.Employees.Add(employeeDto.ToEntity());
                }
            }
            return companyEntity;
            
            
            
           
        }
    }
}
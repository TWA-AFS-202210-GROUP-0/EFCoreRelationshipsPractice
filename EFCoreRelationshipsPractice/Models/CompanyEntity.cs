using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Models
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ProfileEntity? ProfileEntity { get; set; }
        public List<EmployeeEntity>? EmployeesEntity { get; set; }

    }
}

using EFCoreRelationshipsPractice.Repository;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class CompanyEntity
    {
        public CompanyEntity()
        {
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public ProfileEntity? Profile { get; set; }
        public List<EmployeeEntity>? Employees { get; set; }
    }
}

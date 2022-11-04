using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Models
{
    public class EmployeeEntity
    {
        public  int Id  { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public EmployeeDto toDto()
        {
            return new EmployeeDto()
            {
                Name = this.Name,
                Age = this.Age,
            };
        }
    }
}

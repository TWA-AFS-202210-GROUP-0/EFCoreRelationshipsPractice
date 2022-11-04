using EFCoreRelationshipsPractice.Models;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public EmployeeEntity toEmployeeEntity()
        {
            return new EmployeeEntity()
            {
                Name = Name,
                Age = Age,
            };
        }
    }
}
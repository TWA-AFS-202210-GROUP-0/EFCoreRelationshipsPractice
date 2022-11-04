using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelationshipsPractice.Model
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

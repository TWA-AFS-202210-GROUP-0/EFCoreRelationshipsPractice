using System.ComponentModel.DataAnnotations.Schema;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Model;

namespace EFCoreRelationshipsPractice.Repository;


    public class CompanyEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProfileEntity? ProfileEntity { get; set; }

        public List<EmployeeEntity> EmployeeEntities { get; set; }

    }

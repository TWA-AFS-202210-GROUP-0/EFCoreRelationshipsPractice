﻿using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Models
{
    public class EmployeeEntity
    {
        public EmployeeEntity()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreRelationshipsPractice.Model
{
    [Table("Profile")]
    public class ProfileEntity
    {
        public int Id { get; set; }

        public int RegisteredCapital { get; set; }

        public string CertId { get; set; }
    }
}

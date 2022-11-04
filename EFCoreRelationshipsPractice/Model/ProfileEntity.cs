namespace EFCoreRelationshipsPractice.Model
{
    public class ProfileEntity
    {
        public ProfileEntity()
        {
        }

        public int Id { get; set; }
        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
        public string? Name { get; set; }
    }
}
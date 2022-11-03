namespace EFCoreRelationshipsPractice.Repository;

public partial class CompanyDbContext
{
    public class CompanyEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double Revenue { get; set; }
    }
}
using EFCoreRelationshipsPractice.Models;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class ProfileDto
    {
        private ProfileEntity? profileEntity;

        public ProfileDto()
        {
        }

        public ProfileDto(ProfileEntity profileEntity)
        {
            RegisteredCapital = profileEntity.RegisteredCapital;
            this.CertId = profileEntity.CertId;
        }

        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }

        public ProfileEntity toProfileEntity()
        {
            return new ProfileEntity
            {
                RegisteredCapital = this.RegisteredCapital,
                CertId = this.CertId,
            };
        }
    }
}
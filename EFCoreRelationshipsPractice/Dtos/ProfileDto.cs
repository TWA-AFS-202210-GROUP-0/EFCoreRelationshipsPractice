using EFCoreRelationshipsPractice.Repository;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class ProfileDto
    {
        public ProfileDto()
        {
        }

        public ProfileDto(ProfileEntity profile)
        {
            RegisteredCapital = profile.RegisteredCapital;
            CertId = profile.CertId;
        }

        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
        public ProfileEntity? Profile { get; }

        public ProfileEntity ToEntity()
        {
            return new ProfileEntity()
            {
                RegisteredCapital = RegisteredCapital,
                CertId = CertId
            };
        }

        public bool Equals(ProfileDto dto)
        {
            return CertId.Equals(dto.CertId) &&
                RegisteredCapital.Equals(dto.RegisteredCapital);
        }
    }
}
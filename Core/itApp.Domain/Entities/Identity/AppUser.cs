using Microsoft.AspNetCore.Identity;

namespace grammerGame.Domain.Entities.Identity
{
    public class AppUser: IdentityUser<int>
    {
        public string? FullName { get; set; }
        public string? GivenName { get; set; }
        public string? FamilyName { get; set; }
        public string? Photo {  get; set; }
        public string? InitialEnglishLevel { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenEndDate { get; set; }
        // İlişkili Veriler
        public virtual GameProgress GameProgress { get; set; }
        public virtual UserPreferences UserPreferences { get; set; }
        public virtual SocialData SocialData { get; set; }

    }
}

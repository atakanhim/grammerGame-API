using Microsoft.AspNetCore.Identity;

namespace grammerGame.Domain.Entities.Identity
{
    public class AppUser: IdentityUser<int>
    {
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenEndDate { get; set; }


    }
}

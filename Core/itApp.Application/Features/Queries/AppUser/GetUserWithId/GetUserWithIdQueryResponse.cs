

using grammerGame.Application.DTOs.User;
using grammerGame.Domain.Enums;

namespace grammerGame.Application.Features.Queries.AppUser.GetUser
{
    public class GetUserWithIdQueryResponse
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? FullName { get; set; }
        public string? GivenName { get; set; }
        public string? FamilyName { get; set; }
        public string? Photo { get; set; } 
        public int TotalScore { get; set; }
        public string? Rank { get; set; }
    }
}

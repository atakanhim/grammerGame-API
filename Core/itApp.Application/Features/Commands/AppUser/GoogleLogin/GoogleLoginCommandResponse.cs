using grammerGame.Application.DTOs;

namespace grammerGame.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandResponse
    {
        public Token Token { get; set; }
        public int Id { get; set; }
    }
}

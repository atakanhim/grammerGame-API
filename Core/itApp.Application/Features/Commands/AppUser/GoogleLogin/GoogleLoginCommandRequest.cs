using MediatR;

namespace grammerGame.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandRequest : IRequest<GoogleLoginCommandResponse>
    {
        public string IdToken { get; set; }
    }
}

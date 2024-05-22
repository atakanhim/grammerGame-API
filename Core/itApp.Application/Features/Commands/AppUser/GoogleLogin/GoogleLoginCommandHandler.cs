using grammerGame.Application.Abstractions.Services.Authentications;
using grammerGame.Application.DTOs;
using MediatR;


namespace grammerGame.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        readonly IExternalAuthentication _authService;
        public GoogleLoginCommandHandler(IExternalAuthentication authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            (Token token,int id) = await _authService.GoogleLoginAsync(request.IdToken, 15000, 86400);
            return new()
            {
                Token = token,
                Id = id
            };

        }
    }
}

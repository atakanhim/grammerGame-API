using grammerGame.Application.Abstractions.Services;
using grammerGame.Application.Abstractions.Services.Authentications;
using grammerGame.Application.DTOs;
using grammerGame.Application.DTOs.User;
using MediatR;


namespace grammerGame.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IInternalAuthentication _authService;
        readonly IUserService _userService;

        public LoginUserCommandHandler(IInternalAuthentication authService,IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            LoginResponseDTO loginResponseDTO = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 86400, 86400);
            ListUser listuser = await _userService.GetUser(loginResponseDTO.username);
            return new LoginUserSuccessCommandResponse()
            {
                Token = loginResponseDTO.token,
                User = listuser
            };
        }
    }
}

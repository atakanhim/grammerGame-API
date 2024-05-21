using grammerGame.Application.DTOs;
using grammerGame.Application.DTOs.User;


namespace grammerGame.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {

    }
    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
        public Token Token { get; set; }
        public ListUser User { get; set; }
    }
    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
    {
        public string Message { get; set; }
    }
}

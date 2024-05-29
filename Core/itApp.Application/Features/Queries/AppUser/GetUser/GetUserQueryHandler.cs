using grammerGame.Application.Abstractions.Services;
using grammerGame.Application.DTOs.User;
using MediatR;


namespace grammerGame.Application.Features.Queries.AppUser.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, GetUserQueryResponse>
    {
        readonly IUserService _userService;

        public GetUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserQueryResponse> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                ListUser listuser = await _userService.GetUser(request.UserName);
                return new()
                {
                    User = listuser
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
                
        }
    }
}

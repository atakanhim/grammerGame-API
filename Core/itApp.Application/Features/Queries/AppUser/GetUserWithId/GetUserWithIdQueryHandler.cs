using grammerGame.Application.Abstractions.Services;
using grammerGame.Application.DTOs.User;
using MediatR;


namespace grammerGame.Application.Features.Queries.AppUser.GetUser
{
    public class GetUserWithIdQueryHandler : IRequestHandler<GetUserWithIdQueryRequest, GetUserWithIdQueryResponse>
    {
        readonly IUserService _userService;

        public GetUserWithIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserWithIdQueryResponse> Handle(GetUserWithIdQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser user = await _userService.GetUserWithId(request.UserId);

            return new()
            {
               Id = user.Id,
               Email = user.Email!,
               FullName = user.FullName!,
               GivenName = user.GivenName,
               FamilyName = user.FamilyName,
               Photo = user.Photo,
               TotalScore = user.GameProgress.TotalScore,
               Rank = user.GameProgress.Rank
            
            };
                
        }
    }
}

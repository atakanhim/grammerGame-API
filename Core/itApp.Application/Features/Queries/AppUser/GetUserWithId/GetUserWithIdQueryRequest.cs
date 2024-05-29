using MediatR;

namespace grammerGame.Application.Features.Queries.AppUser.GetUser
{
    public class GetUserWithIdQueryRequest : IRequest<GetUserWithIdQueryResponse>
    {   
        public int UserId { get; set; }  
    }
}

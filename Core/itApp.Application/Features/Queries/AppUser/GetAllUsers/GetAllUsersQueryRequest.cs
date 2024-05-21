using MediatR;

namespace grammerGame.Application.Features.Queries.AppUser.GetAllUsers
{
    public class GetAllUserQueryRequest : IRequest<GetAllUserQueryResponse>
    {
        public int? Page { get; set; } = 1; 
        public int? Size { get; set; } = 5;
    }
}

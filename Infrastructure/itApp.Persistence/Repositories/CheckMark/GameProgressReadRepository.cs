

using grammerGame.Application.Repositories;
using grammerGame.Domain.Entities;
using grammerGame.Persistence.Context;

namespace grammerGame.Persistence.Repositories
{
    public class GameProgressReadRepository : ReadRepository<GameProgress>, IGameProgressReadRepository
    {
        public GameProgressReadRepository(GrammerGameDbContext context) : base(context)
        {
        }   
    }
}

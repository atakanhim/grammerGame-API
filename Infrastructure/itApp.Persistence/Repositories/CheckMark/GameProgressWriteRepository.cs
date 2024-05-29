

using grammerGame.Application.Repositories;
using grammerGame.Domain.Entities;
using grammerGame.Persistence.Context;

namespace grammerGame.Persistence.Repositories
{
    public class GameProgressWriteRepository : WriteRepository<GameProgress>, IGameProgressWriteRepository
    {
        public GameProgressWriteRepository(GrammerGameDbContext context) : base(context)
        {
        }   
    }
}

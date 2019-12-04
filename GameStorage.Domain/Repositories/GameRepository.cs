using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStorage.Domain.Repositories
{
    public class GameRepository : BaseRepository<Game>
    {
        public GameRepository(DomainContext context) : base(context) { }
        //TODO: develop API and data validation
    }
}
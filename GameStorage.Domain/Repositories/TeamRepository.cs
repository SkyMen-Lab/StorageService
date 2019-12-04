using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GameStorage.Domain.Repositories
{
    public class TeamRepository : BaseRepository<Team>
    {
        public TeamRepository(DomainContext context) : base(context) { }
        
        //TODO: develop API and data validation
    }
}
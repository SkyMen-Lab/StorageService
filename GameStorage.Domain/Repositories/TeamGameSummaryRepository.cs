using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStorage.Domain.Repositories
{
    public class TeamGameSummaryRepository : BaseRepository<TeamGameSummary>
    {
        public TeamGameSummaryRepository(DomainContext context) : base(context) { }
        
        //TODO: develop API and data validation
    }
}
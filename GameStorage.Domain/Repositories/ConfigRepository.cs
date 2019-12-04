using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GameStorage.Domain.Repositories
{
    public class ConfigRepository : BaseRepository<Config>
    {

        public ConfigRepository(DomainContext context) : base(context) { }
        
        //TODO: develop API and data validation
    }
}
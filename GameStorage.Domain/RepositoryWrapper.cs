using GameStorage.Domain.Repositories;

namespace GameStorage.Domain
{
    public class RepositoryWrapper
    {
        private readonly DomainContext _context;
        private ConfigRepository _configRepository;
        private GameRepository _gameRepository;
        private TeamGameSummaryRepository _summaryRepository;
        private TeamRepository _teamRepository;

        public RepositoryWrapper(DomainContext context)
        {
            _context = context;
        }

        public ConfigRepository ConfigRepository => _configRepository ??= new ConfigRepository(_context);

        public GameRepository GameRepository => _gameRepository ??= new GameRepository(_context);

        public TeamRepository TeamRepository => _teamRepository  ??= new TeamRepository(_context);

        public TeamGameSummaryRepository TeamGameSummaryRepository => _summaryRepository ??= new TeamGameSummaryRepository(_context);

        public void UpdateDB()
        {
            _context.SaveChanges();
        }
    }
}
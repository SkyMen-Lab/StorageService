using System.Collections.Generic;

namespace Storage.Domain.DTOs
{
    public class FinishGameDTO
    {
        public class Team
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public int NumberOfPlayers { get; set; }
            public int Score { get; set; }
        }
        
        public string GameCode { get; set; }
        public List<Team> Teams { get; set; }
        public string WinnerCode { get; set; }
        public int MaxSpeedLevel { get; set; }
    }
}
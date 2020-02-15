using System.Collections.Generic;

namespace Storage.Domain.DTOs
{
    public class StartGameDTO
    {
        public class Team
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public int NumberOfPlayers { get; set; }
            public string RouterIp { get; set; }
        }
        
        public string Code { get; set; }
        public int Duration { get; set; }
        public List<Team> Teams { get; set; }

    }
    
}
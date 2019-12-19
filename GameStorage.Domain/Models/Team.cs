using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStorage.Domain.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [MinLength(2)]
        public string Name { get; set; }
        public int Rank { get; set; }
        public double WinningRate { get; set; }
        public int ConfigId { get; set; }
        [Required]
        public Config Config { get; set; }
        public List<Game> GamesWon { get; set; }
        public List<TeamGameSummary> TeamGameSummaries { get; set; }
    }
}
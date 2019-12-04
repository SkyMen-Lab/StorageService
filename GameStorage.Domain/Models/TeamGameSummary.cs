using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStorage.Domain.Models
{
    public class TeamGameSummary
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        [Required]
        public Team Team { get; set; }
        public bool IsWinner { get; set; }
        public int Score { get; set; }
        public int NumberOfPlayers { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
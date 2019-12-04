using System.ComponentModel.DataAnnotations;

namespace GameStorage.Domain.Models
{
    public class TeamGameSummary
    {
        public int Id { get; set; }
        [Required]
        public Team Team { get; set; }
        public bool IsWinner { get; set; }
        public int Score { get; set; }
        public int NumberOfPlayers { get; set; }
    }
}
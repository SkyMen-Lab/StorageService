using System;
using System.ComponentModel.DataAnnotations;

namespace GameStorage.Domain.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required, MaxLength(10)]
        public string Code { get; set; }
        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }
        [Required]
        public TeamGameSummary TeamOneGameSummary { get; set; }
        [Required]
        public TeamGameSummary TeamTwoGameSummary { get; set; }
        public Team? Winner { get; set; }
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
        //TODO: Replace by User object
        public string CreatedBy { get; set; }
    }
}
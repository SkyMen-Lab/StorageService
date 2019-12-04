using System;

namespace GameStorage.Domain.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }
        public TeamGameSummary TeamOneGameSummary { get; set; }
        public TeamGameSummary TeamTwoGameSummary { get; set; }
        public Team? Winner { get; set; }
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
        //TODO: Replace by User object
        public string CreatedBy { get; set; }
    }
}
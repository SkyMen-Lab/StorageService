using System;

namespace GameStorage.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string IsStarted { get; set; }
        public string IsFinished { get; set; }
        public TeamGameSummary TeamOneGameSummary { get; set; }
        public TeamGameSummary TeamTwoGameSummary { get; set; }
        public Team Winner { get; set; }
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
        //TODO: Replace by User object
        public string CreatedBy { get; set; }
    }
}
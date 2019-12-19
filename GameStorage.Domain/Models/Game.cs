using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStorage.Domain.Models
{
    public class Game
    {
        public int Id { get; set; }
        [MaxLength(10)]
        [MinLength(4)]
        public string Code { get; set; }
        public GameState State { get; set; } = GameState.Created;
        public List<TeamGameSummary> TeamGameSummaries { get; set; }
        public String WinnerCode { get; set; } = "Nobody";
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
        //TODO: Replace by User object
        public string CreatedBy { get; set; }
    }

    public enum GameState
    {
        Created,
        Going,
        Finished,
    }
}
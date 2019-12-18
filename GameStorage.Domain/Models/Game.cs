using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GameStorage.Domain.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required, MaxLength(10)]
        public string Code { get; set; }

        public GameState State { get; set; } = GameState.Created;
        
        [Required]
        public List<TeamGameSummary> TeamGameSummaries { get; set; }
        public String WinnerName { get; set; } = "Nobody";
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
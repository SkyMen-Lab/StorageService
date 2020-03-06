using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage.Domain.Models
{
    public class GameDTO
    {
        public string Code { get; set; }
        public GameState State { get; set; } = GameState.Created;
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
        public string CreatedBy { get; set; }
    }
}
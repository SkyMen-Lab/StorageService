using System;
using Storage.Domain.Models;

namespace Storage.Domain.DTOs
{
    public class GameUpdateDTO
    {
        public string Code { get; set; }
        public GameState State { get; set; } = GameState.Created;
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
        public string CreatedBy { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Storage.Domain.DTOs
{
    public class SetUpGameDTO
    {
        public string FirstTeamCode { get; set; }
        public string SecondTeamCode { get; set; }
        public DateTime Date { get; set; }
        [Range(5, 1440, ErrorMessage = "Duration must be within 5 - 1440 minutes")]
        public int DurationMinutes { get; set; }
        //TODO: Replace by User object
        public string CreatedBy { get; set; }
    }
}
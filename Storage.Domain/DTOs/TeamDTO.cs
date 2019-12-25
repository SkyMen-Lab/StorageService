using System.ComponentModel.DataAnnotations;

namespace Storage.Domain.DTOs
{
    public class TeamDTO
    {
        public string Code { get; set; }
        [MinLength(2, ErrorMessage = "Team name must at least 3 characters")]
        public string Name { get; set; }
        public int Rank { get; set; }
        public double WinningRate { get; set; }
    }
}
namespace GameStorage.Domain.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public double WinningRate { get; set; }
        public Config Config { get; set; }
    }
}
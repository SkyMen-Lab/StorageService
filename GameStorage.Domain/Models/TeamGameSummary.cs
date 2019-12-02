namespace GameStorage.Domain
{
    public class TeamGameSummary
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public bool IsWinner { get; set; }
        public int Score { get; set; }
        public int NumberOfPlayers { get; set; }
    }
}
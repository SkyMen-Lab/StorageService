namespace GameStorage.Domain
{
    public class Config
    {
        public int Id { get; set; }
        public string RouterIpAdress { get; set; }
        public int RouterPort { get; set; }
        public string ConnectionType { get; set; }
        public Team Team { get; set; }
    }
}
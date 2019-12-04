namespace GameStorage.Domain
{
    public class Config
    {
        public int Id { get; set; }
        public string RouterIpAdress { get; set; }
        public int RouterPort { get; set; }
        public ConnectionType ConnectionType { get; set; }
        public Team Team { get; set; }
    }
    
    public enum ConnectionType
    {
        UDP,
        TCP
    }
}
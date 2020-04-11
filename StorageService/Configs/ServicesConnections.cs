namespace StorageService.Configs
{
    public class ServicesConnections : IServiceConnections
    {
        public string GameServiceAddress { get; set; }
        public string AdminServiceAddress { get; set; }
    }

    public interface IServiceConnections
    {
        string GameServiceAddress { get; set; }
        string AdminServiceAddress { get; set; }
    }
}
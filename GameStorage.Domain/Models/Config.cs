using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStorage.Domain.Models
{
    public class Config
    {
        public int Id { get; set; }
        [Required]
        public string RouterIpAddress { get; set; }
        [Required]
        public int RouterPort { get; set; }
        [Required]
        public ConnectionType ConnectionType { get; set; }
        [Required]
        public Team Team { get; set; }
    }
    
    public enum ConnectionType
    {
        UDP,
        TCP
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStorage.Domain.Models
{
    public class Config
    {
        public int Id { get; set; }
        [MinLength(7)]
        [Required]
        public string RouterIpAddress { get; set; }
        [Required]
        public int RouterPort { get; set; }
        [DefaultValue(ConnectionType.UDP)]
        public ConnectionType ConnectionType { get; set; }
        public Team Team { get; set; }
    }
    
    public enum ConnectionType
    {
        UDP,
        TCP
    }
}
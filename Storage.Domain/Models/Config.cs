using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Storage.Domain.Customs;

namespace Storage.Domain.Models
{
    public class Config
    {
        //TODO: IP validation
        public int Id { get; set; }
        [MinLength(7, ErrorMessage = "Invalid IP address")]
        [Required]
        [IPValidate]
        public string RouterIpAddress { get; set; }
        [Required]
        [Range(1025, 65535, ErrorMessage = "Port is out of the range (1025, 65535")]
        public int RouterPort { get; set; }
        [DefaultValue(ConnectionType.UDP)]
        [Range(0, 1, ErrorMessage = "Connection type must either 0 (UDP) or 1 (TCP)")]
        public ConnectionType ConnectionType { get; set; }
        public Team Team { get; set; }
    }
    
    public enum ConnectionType
    {
        UDP,
        TCP
    }
}
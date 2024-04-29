using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanelingSystem.Models
{
    [Table("Accounts")]
    [PrimaryKey("UserId")]
    public class UserAccountModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public Enums.AccountType AccountType { get; set; }
        public byte[]? ProfilePicture { get; set; } = Array.Empty<byte>();
    }
}

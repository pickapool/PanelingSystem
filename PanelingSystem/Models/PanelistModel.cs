using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanelingSystem.Models
{
    [Table("Panels")]
    [PrimaryKey("PanelistId")]
    public class PanelistModel
    {
        public int PanelistId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserAccountModel Panel { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanelingSystem.Models
{
    [Table("Comments")]
    [PrimaryKey("CommentId")]

    public class CommentModel
    {
        public int CommentId { get; set; }
        public int GrouId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserAccountModel Account { get; set; }
    }
}

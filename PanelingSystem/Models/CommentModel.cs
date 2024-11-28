using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace PanelingSystem.Models
{
    [Table("Comments")]
    [PrimaryKey("CommentId")]

    public class CommentModel
    {
        public int CommentId { get; set; }
        public int GroupId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public int UserId { get; set; }
        public Enums.Chapter Chapter { get; set; }
        [ForeignKey("UserId")]
        public UserAccountModel Account { get; set; }
        [NotMapped]
        public bool IsEdit { get; set; } = false;
        [NotMapped]
        [JsonIgnore]
        public bool OpenComment { get; set; }
    }
}

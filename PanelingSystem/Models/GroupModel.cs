using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanelingSystem.Models
{
    [Table("Groups")]
    [PrimaryKey("GroupId")]
    public class GroupModel
    {
        public int GroupId { get; set; }
        public string GroupThesisTitle { get; set; } = string.Empty;
        public string Groupname { get; set; } = string.Empty;
        public string Program { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public Enums.Status Status{ get; set; }
        public int UserId { get; set; }
        [ForeignKey("GroupId")]
        public List<MembersModel> Members { get; set; } = new();
    }
}

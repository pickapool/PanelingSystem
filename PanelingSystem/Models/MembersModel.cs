using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanelingSystem.Models

{
    [Table("Members")]
    [PrimaryKey("MemberId")]
    public class MembersModel
    {
        public int MemberId { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserAccountModel Student { get; set; }
        [NotMapped]
        [JsonIgnore]
        public double Average { get; set; }
    }
}

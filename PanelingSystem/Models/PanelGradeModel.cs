using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PanelingSystem.Models
{
    [Table("PanelGrades")]
    [PrimaryKey("PanelGradeId")]
    public class PanelGradeModel
    {
        public int PanelGradeId {  get; set; }
        public int MemberId { get; set; }
        public double Grade { get; set; }
        public int? UserId { get; set; }
        public Enums.FilePosition DefenseType { get; set; }
        [ForeignKey("UserId")]
        public UserAccountModel? UserAccount { get; set; }
        [JsonIgnore]
        [NotMapped]
        public string? Section { get ;set; }
        [JsonIgnore]
        [NotMapped]
        public string? Year { get ;set; }
        [JsonIgnore]
        [NotMapped]
        public string? Program { get ;set; }
        [JsonIgnore]
        [NotMapped]
        public string? MemberName { get ;set; }


    }
}

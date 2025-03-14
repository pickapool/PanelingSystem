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
        public GroupModel Group { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserAccountModel Student { get; set; }
        [NotMapped]
        [JsonIgnore]
        public double Average { get; set; }
        public double TitleGrade { get; set; }
        public double PreOralGrade { get; set; }
        public double FinalGrade { get; set; }
        [JsonIgnore]
        [NotMapped]
        public bool OpenGrade1 { get; set; }
        [JsonIgnore]
        [NotMapped]
        public bool OpenGrade2 { get; set; }
        [JsonIgnore]
        [NotMapped]
        public bool OpenGrade3 { get; set; }
        [JsonIgnore]
        [NotMapped]
        public PanelGradeModel CurrentPanelGrade { get; set; } = new();
        [JsonIgnore]
        [NotMapped]
        public List<PanelGradeModel> PanelGrades { get; set; } = new();
    }
}

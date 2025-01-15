using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

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
        public string Section { get; set; } = string.Empty;
        public Enums.Status Status{ get; set; }
        public int UserId { get; set; }
        [ForeignKey("GroupId")]
        public List<MembersModel> Members { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public bool IsShowDetails { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<ScheduleModel> ListOfSchedules { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public List<CapstoneFileModel> ListOfCapstionFiles { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public CapstoneFileModel Title1 { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public CapstoneFileModel Title2 { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public CapstoneFileModel Title3 { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public CapstoneFileModel Chapter1 { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public CapstoneFileModel Chapter2 { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public CapstoneFileModel Chapter3 { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public CapstoneFileModel Chapter4 { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public CapstoneFileModel Chapter5 { get; set; } = new();
        [NotMapped]
        [JsonIgnore]
        public List<CommentModel> Comments { get; set; } = new();

        [NotMapped]
        [JsonIgnore]
        public bool title1Open { get; set; }
        [NotMapped]
        [JsonIgnore]
        public bool title2Open { get; set; }
        [NotMapped]
        [JsonIgnore]
        public bool chapter1Open { get; set; }
        [NotMapped]
        [JsonIgnore]
        public bool chapter2Open { get; set; }
        [NotMapped]
        [JsonIgnore]
        public bool chapter3Open { get; set; }
        [NotMapped]
        [JsonIgnore]
        public bool chapter4Open { get; set; }
        [NotMapped]
        [JsonIgnore]
        public bool chapter5Open { get; set; }
        [NotMapped]
        [JsonIgnore]
        public bool title3Open { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<PanelistModel> ListOfPanels { get; set; } = new();

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace PanelingSystem.Models
{
    public class ReportModel
    {
        public int ScheduleId { get; set; }
        public int GroupId { get; set; }
        public GroupModel Group { get; set; }
        public Enums.FilePosition DefenseType { get; set; }
        public Enums.Status Status { get; set; }
        public string StatusText { get; set; }
        public string DefenseTypeText { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Text { get; set; }
        public string GroupThesisTitle { get; set; } = string.Empty;
        public string Groupname { get; set; } = string.Empty;
        public string Program { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public int MemberId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;


    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanelingSystem.Models
{
    [Table("Grades")]
    [PrimaryKey("GradeId")]
    public class ScheduleModel
    {
        public int ScheduleId { get; set; }
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public GroupModel Group { get; set; }
        public Enums.FilePosition DefenseType{ get; set; }
        public Enums.Status Status{ get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Text { get; set; }
    }
}
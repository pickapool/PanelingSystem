using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PanelingSystem.Models
{
    [Table("Grades")]
    [PrimaryKey("GradeId")]
    public class GradeModel
    {
        public int GradeId { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public double Grade { get; set; }
        [ForeignKey("UserId")]
        public UserAccountModel Student {  get; set; }
        public string GradedBy { get; set; } = string.Empty;
        public int GradedById { get; set; }
    }
}

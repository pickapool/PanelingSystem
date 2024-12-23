using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanelingSystem.Models
{
    [Table("DefenseVerdicts")]
    [PrimaryKey("DefenseVerdictId")]
    public class DefenseVerdictModel
    {
        public long DefenseVerdictId { get; set; }
        public long GroupId { get; set; }
        public Enums.Chapter Chapter { get; set; }
        public Enums.Status Status { get; set; }
        public double Grade { get; set; }
    }   
}

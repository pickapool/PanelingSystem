using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

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
        public UserAccountModel? UserAccount { get; set; }

    }
}

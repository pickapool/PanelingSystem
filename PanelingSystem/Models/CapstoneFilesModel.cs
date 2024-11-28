using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PanelingSystem.Models
{
    [Table("CapstoneFiles")]
    [PrimaryKey("CapstoneFileId")]
    public class CapstoneFileModel
    {
        public int CapstoneFileId { get; set; }
        public int GroupId { get; set; }
        public DateTime? DateAdded { get; set; }
        public byte[]? File { get; set; } = new byte[0];
        public string? FileName { get; set; }
        public Enums.Chapter Chapter { get; set; }
        public string Title { get; set; }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace PanelingSystem.Models
{
    [Table("Files")]
    [PrimaryKey("FileId")]
    public class FileModel
    {
        public int FileId { get; set; }
        public int GroupId { get; set; }
        public Enums.FilePosition FilePosition{ get; set; }
        public byte[] File { get; set; } = Array.Empty<byte>();
        public string FileName { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        [NotMapped]
        public IBrowserFile BrowserFile { get; set; } = null;
    }
}
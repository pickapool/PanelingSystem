namespace PanelingSystem.Models
{
    public class FilterParameter{
        public bool IsProgram;
        public string ProgramName = string.Empty;
        public bool IsSection;
        public string SectionName = string.Empty;
        public bool IsYear;
        public string Year = string.Empty;
        public bool IsChapter;
        public Enums.FilePosition GradeType;
    }
}
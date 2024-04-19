namespace PanelingSystem.Models
{
    public class Enums
    {
        public enum Status
        {
            InProgress = 0,
            Failed = 1,
            Success = 2,
            Pending = 3,
            Rejected = 4,
        }
        public enum AccountType
        {
            Admin = 0,
            Instructor = 1,
            Student = 2,
            Panelist = 3,
            Adviser = 4,
        }
        public enum FilePosition
        {
            Title = 0,
            PreOral = 1,
            Finals = 2,
        }
    }
}

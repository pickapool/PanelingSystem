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
            Completed = 5,
            Redefend = 6,
        }
        public enum AccountType
        {
            Admin = 0,
            Instructor = 1,
            Student = 2,
            Panelist = 3,
            Adviser = 4,
        }
        public enum AccountTypeForAdmin
        {
            Admin = 0,
            Instructor = 1,
            Panelist = 3,
            Adviser = 4,
        }
        public enum AccountTypeForInstructor
        {
            Student = 2,
        }
        public enum FilePosition
        {
            Title = 0,
            PreOral = 1,
            Finals = 2,
        }
        public enum Chapter
        {
            Chapter1 = 0,
            Chapter2 = 1,
            Chapter3 = 2,
            Chapter4 = 3,
            Chapter5 = 4
        }

    }
}

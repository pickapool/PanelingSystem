using System.ComponentModel;

namespace PanelingSystem.Models
{
    public class Enums
    {
        public enum Status
        {
            // InProgress = 0,
            // Failed = 1,
            // Success = 2,
            // Pending = 3,
            Rejected = 4,
            Completed = 5,
            Redefend = 6,
            Approved = 7,
            AcceptedWithRevisions = 8,
        }
        public enum AccountType
        {
            Admin = 0,
            Instructor = 1,
            Student = 2,
            [Description("Panelist/Adviser")]
            Panelist_Adviser
        }
        public enum AccountTypeForAdmin
        {
            Admin = 0
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
            Chapter5 = 4,
            [Description("Title 1")]
            Title1 = 5,
            [Description("Title 2")]
            Title2 = 6,
            [Description("Title 3")]
            Title3 = 7
        }

    }
}

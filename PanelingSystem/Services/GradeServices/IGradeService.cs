using PanelingSystem.Models;

namespace PanelingSystem.Services.GradeServices
{
    public interface IGradeService
    {
        bool GradeModelExists(int id);
        Task<GradeModel> DeleteGradeModel(int id);
        Task<GradeModel> PostGradeModel(GradeModel gradeModel);
        Task<GradeModel> PutGradeModel(int id, GradeModel gradeModel);
        Task<IEnumerable<GradeModel>> GetGradeModel();
        Task<GradeModel> GetStudentGrade(int userId);
    }
}

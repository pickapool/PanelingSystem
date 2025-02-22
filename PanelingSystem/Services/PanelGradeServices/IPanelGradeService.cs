using PanelingSystem.Models;

namespace PanelingSystem.Services.PanelGradeServices
{
    public interface IPanelGradeService
    {
        Task<IEnumerable<PanelGradeModel>> GetPanelGrades();
        Task<PanelGradeModel> GetPanelGrade(int accountId, int memberId);
        Task<PanelGradeModel> PutPanelGrade(int id, PanelGradeModel PanelGradeModel);
        Task<PanelGradeModel> PostPanelGrade(PanelGradeModel PanelGradeModel);
        Task<PanelGradeModel> DeletePanelGrade(int id);
        Task<List<PanelGradeModel>> GetMemeberGrades(int memberId);
    }
}

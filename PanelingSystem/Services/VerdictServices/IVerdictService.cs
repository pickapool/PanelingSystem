using PanelingSystem.Models;

namespace PanelingSystem.Services.GradeServices
{
    public interface IVerdictService
    {
        Task<DefenseVerdictModel> DeleteDefenseVerdictModel(int id);
        Task<DefenseVerdictModel> PostDefenseVerdictModel(DefenseVerdictModel DefenseVerdictModel);
        Task<DefenseVerdictModel> PutDefenseVerdictModel(int id, DefenseVerdictModel DefenseVerdictModel);
        Task<List<DefenseVerdictModel>> GetDefenseVerdictModel();
        Task<DefenseVerdictModel> GetVerdict(long GroupId, Enums.Chapter chapter);
        bool DefenseVerdictModelExists(int id);
    }
}

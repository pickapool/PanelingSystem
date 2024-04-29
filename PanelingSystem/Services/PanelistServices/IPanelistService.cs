using PanelingSystem.Models;

namespace PanelingSystem.Services.PanelistServices
{
    public interface IPanelistService
    {
        Task<IEnumerable<PanelistModel>> GetPanels();
        Task<IEnumerable<PanelistModel>> GetPanelGroup(int groupId);
        Task<PanelistModel> GetPanelistModel(int id);
        Task<PanelistModel> PutPanelistModel(int id, PanelistModel panelistModel);
        Task<PanelistModel> PostPanelistModel(PanelistModel panelistModel);
        Task<PanelistModel> DeletePanelistModel(int id);
    }
}

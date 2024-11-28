using PanelingSystem.Models;
using System.Collections.Generic;

namespace PanelingSystem.Services.CapstoneFilesServices
{
    public interface ICapstoneFileService
    {
        Task<IEnumerable<CapstoneFileModel>> GetCapstoneFiles();
        Task<CapstoneFileModel> GetCapstoneFileModel(int id);
        Task<CapstoneFileModel> PutCapstoneFileModel(int id, CapstoneFileModel capstoneFileModel);
        Task<CapstoneFileModel> PostCapstoneFileModel(CapstoneFileModel capstoneFileModel);
        Task<CapstoneFileModel> DeleteCapstoneFileModel(int id);
        bool CapstoneFileModelExists(int id);
        Task<IEnumerable<CapstoneFileModel>> GetCapstoneFilesWithGroup(int GroupId);
    }
}

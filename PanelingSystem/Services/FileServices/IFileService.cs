using PanelingSystem.Models;

namespace PanelingSystem.Services.FileServices
{
    public interface IFileService
    {
        Task<IEnumerable<FileModel>> GetFiles();
        Task<IEnumerable<FileModel>> GetFilesPerPosition(Enums.FilePosition position, int groupId);
        Task<FileModel> GetFileModel(int id);
        Task<FileModel> PutFileModel(int id, FileModel fileModel);
        Task<FileModel> PostFileModel(FileModel fileModel);
        Task<FileModel> DeleteFileModel(int id);
        
    }
}

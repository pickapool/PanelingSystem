using PanelingSystem.Models;

namespace PanelingSystem.Services.GroupServices
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupModel>> GetGroups();
        Task<GroupModel> GetGroupModel(int id);
        Task<GroupModel> PutGroupModel(int id, GroupModel groupModel);
        Task<GroupModel> PostGroupModel(GroupModel groupModel);
        Task<GroupModel> DeleteGroupModel(int id);
        Task<IEnumerable<GroupModel>> GetMyGroups(int userId);
        Task<IEnumerable<GroupModel>> GetGroupsWithUsers();
        Task<IEnumerable<GroupModel>> GetMyGroups(int userId, FilterParameter param);
        Task<IEnumerable<GroupModel>> GetGroupsWithUsers(FilterParameter param);
        Task<IEnumerable<GroupModel>> GetGroups(FilterParameter param);
    }
}

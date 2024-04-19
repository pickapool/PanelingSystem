using PanelingSystem.Models;

namespace PanelingSystem.Services.MemberServices
{
    public interface IMemberService
    {
        Task<IEnumerable<MembersModel>> GetMembers();
        Task<MembersModel> GetMembersModel(int id);
        Task<MembersModel> PutMembersModel(int id, MembersModel membersModel);
        Task<MembersModel> PostMembersModel(MembersModel membersModel);
        Task<MembersModel> DeleteMembersModel(int id);
        Task<IEnumerable<MembersModel>> GetMyGroupMembers(int groupId);
    }
}

using PanelingSystem.Models;
using System.Collections.Generic;

namespace PanelingSystem.Services.CommentServices
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentModel>> GetComments(Enums.Chapter chap);
        Task<CommentModel> GetCommentModel(int id);
        Task<CommentModel> PutCommentModel(int id, CommentModel commentModel);
        Task<CommentModel> PostCommentModel(CommentModel commentModel);
        Task<CommentModel> DeleteCommentModel(int id);
         Task<IEnumerable<CommentModel>> GetCommentsByGroupAndChapter(GroupModel group, Enums.Chapter chapter);
    }
}

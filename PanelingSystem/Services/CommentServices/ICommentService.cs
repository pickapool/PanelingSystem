using PanelingSystem.Models;

namespace PanelingSystem.Services.CommentServices
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentModel>> GetComments(Enums.Chapter chap);
        Task<CommentModel> GetCommentModel(int id);
        Task<CommentModel> PutCommentModel(int id, CommentModel commentModel);
        Task<CommentModel> PostCommentModel(CommentModel commentModel);
        Task<CommentModel> DeleteCommentModel(int id);
    }
}

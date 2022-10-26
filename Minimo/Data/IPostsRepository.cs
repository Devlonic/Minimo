using Minimo.Models;

namespace Minimo.Data {
    public interface IPostsRepository {
        Task<PreviewPost> GetMainPostAsync();
        Task<List<PreviewPost>> GetPreviewPostListAsync(int skip, int count);
        Task<List<PreviewPost>> GetRandomPreviewPostListAsync(int count, Post? toSkip = null);
        Task<List<PreviewPost>> GetTopCommentedPosts(int count);
        Task<Post?> GetPostAsync(int id);
        Task<List<Comment>> GetCommentsForPostAsync(Post post);
        Task PushComment(int idPost, string authorName, string text, int? replyTo);
    }
}

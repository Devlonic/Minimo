using Minimo.Models;

namespace Minimo.Data {
    public interface IPostsRepository {
        Task<List<PreviewPost>> GetPreviewPostListAsync();
        Task<Post?> GetPostAsync(int id);
    }
}

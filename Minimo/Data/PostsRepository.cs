using Microsoft.EntityFrameworkCore;
using Minimo.Models;

namespace Minimo.Data {
    public class PostsRepository : IPostsRepository, IDisposable {
        private MainDbContext db;

        public PostsRepository(MainDbContext context) {
            this.db = context;
        }


        public async Task<List<PreviewPost>> GetPreviewPostListAsync() {
            var posts = await db.Posts.Include(p => p.ThumbImage).Include(p => p.Category).Select(x => new PreviewPost() { Description = x.Description, ID_Category = x.ID_Category, ID_ThumbImage = x.ID_ThumbImage, Title = x.Title, ThumbImage = x.ThumbImage, Category = x.Category }).ToListAsync();
            return posts;
        }
        public async Task<Post?> GetPostAsync(int id) {
            var query = db.Posts.Where(p => p.ID == id).Include(p => p.Category).Include(p => p.Images);
            var post = await query.SingleOrDefaultAsync();
            return post;
        }

        private bool disposed;
        protected virtual void Dispose(bool disposing) {
            if ( !disposed ) {
                if ( disposing ) {
                    db.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose() {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

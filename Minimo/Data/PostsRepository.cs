using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Minimo.Models;
using System.Buffers.Text;
using System.Text;

namespace Minimo.Data {
    public class PostsRepository : IPostsRepository, IDisposable {
        private MainDbContext db;

        public PostsRepository(MainDbContext context) {
            this.db = context;
        }

        public async Task<PreviewPost?> GetMainPostAsync() {
            var post = await GetRandomPost();
            return post;
        }
        public async Task<List<PreviewPost>> GetPreviewPostListAsync(int skip, int count) {
            var posts = await db.Posts.
                Include(p => p.ThumbImage).
                Include(p => p.Category).
                Select(x => new PreviewPost() { ID = x.ID, Description = x.Description, ID_Category = x.ID_Category, ID_ThumbImage = x.ID_ThumbImage, Title = x.Title, ThumbImage = x.ThumbImage, Category = x.Category,  }).
                Skip(skip).
                Take(count).
                ToListAsync();
            return posts;
        }
        public async Task<Post?> GetPostAsync(int id) {
            var query = db.Posts.Where(p => p.ID == id).Include(p => p.Category).Include(p=>p.ThumbImage).Include(p => p.Images);
            var post = await query.SingleOrDefaultAsync();
            return post;
        }
        public async Task<List<Comment>> GetCommentsForPostAsync(Post post) {
            var query = db.Comments.Where(c => c.ID_Post == post.ID).Include(c=>c.CommentReply);
            var comments = await query.ToListAsync();
            return comments;
        }
        public async Task<PreviewPost?> GetPreviewPostAsync(int id) {
            var query = db.Posts.Where(p => p.ID == id).Include(p => p.Category).Include(p => p.Images).Select(x=>new PreviewPost() { Description = x.Description, ID_Category = x.ID_Category, ID_ThumbImage = x.ID_ThumbImage, Title = x.Title, ThumbImage = x.ThumbImage, Category = x.Category });
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
        private async Task<PreviewPost> GetRandomPost() {
            var post = await
                db.Posts.
                Include(p => p.ThumbImage).
                Include(p => p.Category).
                Select(x => new PreviewPost() {  ID = x.ID, Description = x.Description, ID_Category = x.ID_Category, ID_ThumbImage = x.ID_ThumbImage, Title = x.Title, ThumbImage = x.ThumbImage, Category = x.Category }).
                OrderBy(p => Guid.NewGuid()).
                Take(1).SingleAsync();

            return post;
        }
        public async Task<List<PreviewPost>> GetRandomPreviewPostListAsync(int count, Post? toSkip = null) {
            var posts = await 
                db.Posts.
                Include(p => p.ThumbImage).
                Select(x => new PreviewPost() { ID = x.ID, ID_ThumbImage = x.ID_ThumbImage, Title = x.Title, ThumbImage = x.ThumbImage }).
                Where( x => toSkip != null? x.ID != toSkip.ID : true).
                OrderBy(p=>Guid.NewGuid()).
                Take(count).
                ToListAsync();

            return posts;
        }

        private int GetIntByString(string str) {
            var hash = System.Security.Cryptography.MD5CryptoServiceProvider.Create().ComputeHash(Encoding.UTF8.GetBytes(str)).Take(4);
            return BitConverter.ToInt32(hash.ToArray(), 0);
        }
        private string GetColorByString(string str) {
            return "#" + GetIntByString(str).ToString("X4").Remove(6);
        }

        public async Task PushComment(int idPost, string authorName, string text, int? replyTo) {
            var color = GetColorByString(authorName);
            db.Comments.Add(new Comment() {
                Author = authorName,
                ID_Post = idPost,
                Text = text,
                Date = DateTime.Now,
                PortraitColor = color,
                ID_CommentReply = replyTo,
            });
            await db.SaveChangesAsync();
        }

        public async Task<List<PreviewPost>> GetTopCommentedPosts(int count) {
            var topCommentedPosts = from p in db.Posts
                                    let countCommentsPerPost = (from c in db.Comments
                                                                where c.ID_Post == p.ID
                                                                select c).Count()
                                    orderby countCommentsPerPost descending
                                    select new PreviewPost {
                                        ID = p.ID,
                                        CommentsCount = countCommentsPerPost,
                                        Title = p.Title,
                                    };

            return await topCommentedPosts.Take(3).ToListAsync();
        }
    }
}

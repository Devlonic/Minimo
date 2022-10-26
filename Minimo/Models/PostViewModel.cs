namespace Minimo.Models {
    public class PostViewModel {
        public Post? Post { get; set; }
        public IEnumerable<PreviewPost>? AlsoLikePosts { get; set; }
        public IEnumerable<Comment>? Comments { get; set; }
        public IEnumerable<PreviewPost>? MostCommentedPosts { get; set; }

    }
}

namespace Minimo.Models {

    public class IndexViewModel {
        public IndexViewModel(PreviewPost mainPost, IEnumerable<PreviewPost> topPosts, IEnumerable<PreviewPost> otherPosts) {
            this.MainPost = mainPost;
            this.TopPosts = topPosts;
            this.OtherPosts = otherPosts;
        }

        public PreviewPost MainPost { get; set; }
        public IEnumerable<PreviewPost> TopPosts { get; set; }
        public IEnumerable<PreviewPost> OtherPosts { get; set; }
    }
}

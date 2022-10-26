using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minimo.Models {
    public class PreviewPost {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public int? ID_Category { get; set; }

        [ForeignKey("ID_Category")]
        public Category? Category { get; set; }

        public int? ID_ThumbImage { get; set; }

        [ForeignKey("ID_ThumbImage")]
        public Image? ThumbImage { get; set; }

        public int? CommentsCount { get; set; }

        public PreviewPost() {

        }
        public PreviewPost(Post post) {
            ID = post.ID;
            Title = post.Title;
            Description = post.Description;
            ID_Category = post.ID_Category;
            ID_ThumbImage = post.ID_ThumbImage;
            Category = post.Category;
            ThumbImage = post.ThumbImage;
        }
        public override int GetHashCode() {
            return ID;
        }
    }
}

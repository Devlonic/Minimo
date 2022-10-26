using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minimo.Models {
    public class Post {
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

        public virtual ICollection<Image>? Images { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }

        public override int GetHashCode() {
            return ID;
        }
    }
}

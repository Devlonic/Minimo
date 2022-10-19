using System.ComponentModel.DataAnnotations.Schema;

namespace Minimo.Models {
    public class PreviewPost {
        public string? Title { get; set; }
        public string? Description { get; set; }

        public int? ID_Category { get; set; }

        [ForeignKey("ID_Category")]
        public Category? Category { get; set; }

        public int? ID_ThumbImage { get; set; }

        [ForeignKey("ID_ThumbImage")]
        public Image? ThumbImage { get; set; }
    }
}

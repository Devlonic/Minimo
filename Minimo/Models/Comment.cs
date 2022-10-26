using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minimo.Models {
    public class Comment {
        [Key]
        public int ID { get; set; }

        public string? PortraitColor { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Author { get; set; }
        public DateTime? Date { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string? Text { get; set; }

        public int? ID_CommentReply { get; set; }
        [ForeignKey("ID_CommentReply")]
        public Comment? CommentReply { get; set; }

        public int? ID_Post { get; set; }

        [ForeignKey("ID_Post")]
        public Post? Post { get; set; }
    }
}

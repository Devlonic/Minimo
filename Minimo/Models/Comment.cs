using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minimo.Models {
    public class Comment {
        [Key]
        public int ID { get; set; }

        public string? PortraitColor { get; set; }
        public string? Author { get; set; }
        public DateTime? Date { get; set; }
        public string? Text { get; set; }

        public int? ID_Post { get; set; }

        [ForeignKey("ID_Post")]
        public Post? Post { get; set; }
    }
}

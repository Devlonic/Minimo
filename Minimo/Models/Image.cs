using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minimo.Models {

    public class Image {
        [Key]
        public int ID { get; set; }

        public string? Path { get; set; }

        public int? ID_Post { get; set; }
    }
}

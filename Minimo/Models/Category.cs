using System.ComponentModel.DataAnnotations;

namespace Minimo.Models {
    public class Category {
        [Key]
        public int ID { get; set; }

        public string? Name { get; set; }
    }
}

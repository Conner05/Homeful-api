using System.ComponentModel.DataAnnotations;
namespace WebApplication.Models {
    public class Need {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public bool Medical { get; set; }
    }
}
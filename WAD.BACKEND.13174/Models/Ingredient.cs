using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAD.BACKEND._13174.Models
{
    public class Ingredient
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [MaxLength(50, ErrorMessage = "Quantity cannot exceed 50 characters.")]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "RecipeId is required.")]
        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public Recipe? Recipe { get; set; }
    }
}

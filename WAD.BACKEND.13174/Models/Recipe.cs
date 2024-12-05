using System;
using System.ComponentModel.DataAnnotations;

namespace WAD.BACKEND._13174.Models
{
    public class Recipe
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Cuisine is required.")]
        [MaxLength(50, ErrorMessage = "Cuisine cannot exceed 50 characters.")]
        public string Cuisine { get; set; }

        [Required(ErrorMessage = "CreatedDate is required.")]
        public DateTime CreatedDate { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace RecipeCollections.Models
{
    public class Creator
    {
        [Key]
        [Display(Name="Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Creator Name")]
        public string Name { get; set; }

        [Display(Name = "Number of Recipes")]
        public int NumberOfRecipies { get; set; }

        [Display(Name = "Average Rating")]
        public float AverageRating { get; set; }
    }
}

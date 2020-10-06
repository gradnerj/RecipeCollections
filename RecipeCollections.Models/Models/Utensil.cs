using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeCollections.Models
{
    public class Utensil
    {
        [Key]
        [Display(Name ="Id")]
        public int Id { get; set; }

        [ForeignKey("Recipe")]
        [Display(Name ="Recipe Id")]
        public int RecipeId { get; set; }

        [Display(Name ="Name")]
        public string Name { get; set; }

        [Display(Name = "Cost")]
        public float Cost { get; set; }
    }
}

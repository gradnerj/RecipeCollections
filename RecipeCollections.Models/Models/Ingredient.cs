using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeCollections.Models.Models
{
    public class Ingredient
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [ForeignKey("Recipe")]
        [Display(Name ="Recipe Id")]
        public int RecipeId { get; set; }
        [Display(Name="Name")]
        public string Name { get; set; }

        [Display(Name="Quantity")]
        public string Qty { get; set; }
    }
}

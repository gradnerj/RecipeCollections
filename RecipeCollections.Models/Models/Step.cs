using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeCollections.Models.Models
{
    public class Step
    {
        [Key]
        [Display(Name ="Id")]
        public int Id { get; set; }

        [ForeignKey("Recipe")]
        [Display(Name ="Recipe Id")]
        public int RecipeId { get; set; }

        [Display(Name ="Description")]
        public string Description { get; set; }
    }
}

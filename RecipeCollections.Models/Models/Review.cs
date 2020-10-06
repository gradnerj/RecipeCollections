using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeCollections.Models
{
    public class Review
    {
        [Key]
        [Display(Name ="Id")]
        public int Id { get; set; }

        [ForeignKey("Creator")]
        [Display(Name ="Creator Id")]
        public int CreatorId { get; set; }

        [ForeignKey("Recipe")]
        [Display(Name ="Recipe Id")]
        public int RecipeId { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }
    }
}

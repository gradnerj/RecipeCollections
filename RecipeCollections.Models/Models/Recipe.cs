
using RecipeCollections.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeCollections.Models
{
    public class Recipe
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        [Display(Name = "Creator Id")]
        public string CreatorId { get; set; }

        [Display(Name="Recipe Title")]
        public string Title { get; set; }

        [Display(Name ="Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Display(Name = "Prep. Time")]
        public int PrepTime { get; set; }

        [Display(Name = "Cook Time")]
        public int CookTime { get; set; }

        [Display(Name = "Feeds # People")]
        public int FeedsQty { get; set; }

        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }

        [Display(Name ="Instructions")]
        public string Instructions { get; set; }

    }
}

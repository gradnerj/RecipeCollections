
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeCollections.Models.Models
{
    public class Recipe
    {

        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [ForeignKey("Creator")]
        [Display(Name = "Creator Id")]
        public int CreatorId { get; set; }

        [Display(Name="Recipe Title")]
        public string Title { get; set; }

        [Display(Name ="Category")]
        public string Category { get; set; }

        [Display(Name = "Prep. Time")]
        public int PrepTime { get; set; }

        [Display(Name = "Cook Time")]
        public int CookTime { get; set; }

        [Display(Name = "Feeds # People")]
        public int FeedsQty { get; set; }

        [Display(Name = "Photo")]
        public string PhotoPath { get; set; }

        //[Display(Name = "Utensils Required")]
        //public IEnumerable<Utensil> Utensils { get; set; }

        //[Display(Name ="Steps")]
        //public IEnumerable<Step> Steps { get; set; }

    }
}

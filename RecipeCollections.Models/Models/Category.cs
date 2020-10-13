using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeCollections.Models {
    public class Category {

        [Key]
        [Display(Name ="Id")]
        public int Id { get; set; }

        [Display(Name="Category Name")]
        public string Name { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecipeCollections.Models {
    public class RecentlyViewed {

        public RecentlyViewed() {
            Count = 1;
        }
        public int Count { get; set; }
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string ApplicationUserId { get; set; }
        [NotMapped]
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }

        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

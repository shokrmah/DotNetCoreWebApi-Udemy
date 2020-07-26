using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Entity
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Headline must be 10 and 200")]
        public string HeadLine { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 20, ErrorMessage = "Headline must be 20 and 2000")]
        public string ReviewText { get; set; }

        [Required]
        [Range(1,5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }
        public virtual Reviewer Reviewer { get; set; }
        public virtual Book Book { get; set; }
    }
}

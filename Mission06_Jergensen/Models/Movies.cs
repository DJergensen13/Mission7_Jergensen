using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Jergensen.Models
{
    public class Movies
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("CategoryID")]
        public int? CategoryId { get; set; }
        public Category? CategoryName { get; set; }
        [Required(ErrorMessage = "Sorry, you need to enter a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Sorry, you need to enter a title")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be at least 1888.")]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "Sorry, please specify if the movie was edited or not")]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "Sorry, you must specify if it has been copied to Plex.")]
        public int CopiedToPlex { get; set; }
        [MaxLength(25, ErrorMessage = "Notes needs to be 25 characters or less")]
        public string? Notes { get; set; }
    }
}

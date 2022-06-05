using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Genre
    {
        [Required(ErrorMessage = "Genre is required.")]
        public byte Id { get; set; }

        //[Required]
        [StringLength(255)]
        public string Name { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;

namespace LibraryApiLinux.dtos
{
    public class BookUpdateDto
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        public string? Genre { get; set; }

        public string? Image { get; set; }

        [Required]
        public int? Stock { get; set; }

        public bool IsAvailable { get; set; }

        public bool IsInCart { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
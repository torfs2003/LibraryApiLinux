﻿namespace LibraryApiLinux.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? Genre { get; set; }

        public string? Image { get; set; }

        public int? Stock { get; set; }

        public bool IsAvailable { get; set; } = true;
        public bool IsInCart { get; set; } = false;

        public DateTime? DueDate { get; set; }

    }
}


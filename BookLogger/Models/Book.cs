using System;
using System.ComponentModel.DataAnnotations;

namespace BookLogger.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int Pages { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        // Foreign keys
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }

        // Navigation properties
        public virtual Author? Author { get; set; }
        public virtual Publisher? Publisher { get; set; }
    }
}

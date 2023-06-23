using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YourNamespace.Models;

namespace BookLogger.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        // Navigation property
        public virtual ICollection<Book> Books { get; set; }
    }
}

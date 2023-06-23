using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Navigation property
        public virtual ICollection<Book> Books { get; set; }
    }
}

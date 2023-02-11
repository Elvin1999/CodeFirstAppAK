using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApp.Entities
{
    public class Category
    {
        [Key]
        public int MyId { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage ="Category name must be 30 characters or less")]
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public Category()
        {
            Books = new List<Book>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

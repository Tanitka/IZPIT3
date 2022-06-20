using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class Books
    {
        [Key]
        public int ID { get; private set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Range(10, 2000)]
        public int Pages { get; set; }

        [Required]
        [MaxLength(40)]
        public string Author { get; set; }

        public List<Customers> Customers { get; set; }

        private Books()
        {

        }

        public Books(string name, int pages, string author)
        {
            this.Name = name;
            this.Pages = pages;
            this.Author = author;
        }


        public Books(int id, string name, int pages, string author)
            : this(name, pages, author)
        {
            ID = id;
        }
    }
}

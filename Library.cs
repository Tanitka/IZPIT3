using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class Library
    {
        [Key]
        public string EIK { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string Address { get; set; }

        public List<Books> Books { get; set; }

        public List<Customers> Customers { get; set; }



        private Library()
        {

        }

        public Library(string eik, string name, string address)
        {
            this.EIK = eik;
            this.Name = name;
            this.Address = address;
        }


    }
}

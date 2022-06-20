using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class Customers
    {
        [Key]
        public int ID { get; private set; }

        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string SecondName { get; set; }

        public int Age { get; set; }

        public List<Books> Books { get; set; }

        private Customers()
        {

        }

        public Customers(string firstName, string secondName, int age)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Age = age;
        }

        public Customers(int id, string firstName, string secondName, int age)
            : this(firstName, secondName, age)
        {
            ID = id;
        }
    }
}

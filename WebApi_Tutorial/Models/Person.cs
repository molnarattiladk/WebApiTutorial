using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Tutorial.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Job { get; set; }

        public string Interests { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Account
    {
        [Key]
        public int Number { get; set; }

        public int Balance { get; set; }
        public string Label { get; set; }
        public int Owner { get; set; }

    }
}
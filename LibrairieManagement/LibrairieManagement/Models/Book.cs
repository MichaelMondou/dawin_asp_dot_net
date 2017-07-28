using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrairieManagement.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public Author Author { get; set; }
        public int Amount { get; set; }
    }
}
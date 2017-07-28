using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrairieManagement.Models
{
    public class Book : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public Author Author { get; set; }
        public int Amount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Title) && string.IsNullOrWhiteSpace(Author.Name))
                yield return new ValidationResult("Vous devez saisir le titre et le nom de l'auteur", new[] { "Title", "Author" });
        }
    }
}
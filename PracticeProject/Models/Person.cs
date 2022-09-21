using Radzen.Blazor;
using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [RegularExpression(@"\D+", ErrorMessage = "Invalid value")]
        [Required, MaxLength(25)]
        public string FirstName { get; set; }

        [RegularExpression(@"\D+", ErrorMessage = "Invalid value")]
        [Required, MaxLength(40)]
        public string LastName { get; set; }

        [RegularExpression(@"\d+", ErrorMessage = "Invalid value")]
        [Required, Range(1,122, ErrorMessage = "Please enter an age between 1 - 122")]
        public int Age { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public List<Relation> Person1Relations { get; set; }
        public List<Relation> Person2Relations { get; set; }

    }
}

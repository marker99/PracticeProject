using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeProject.Models
{
    public class Relation
    {
        [Key]
        public int RelationId { get; set; }

        public int PersonId1 { get; set; }
        public Person Person1 { get; set; }

        public int PersonId2 { get; set; }
        public Person Person2 { get; set; }

        [Required]
        [RegularExpression(@"\D+", ErrorMessage = "Invalid value")]
        public string RelationType { get; set; }
        
    }
}

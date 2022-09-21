using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Models
{
    public class Relation
    {
        [Key]
        public int RelationId { get; set; }

        public int PersonId1 { get; set; }
        public Person person1 { get; set; }

        public int PersonId2 { get; set; }
        public Person person2 { get; set; }

        [RegularExpression(@"\D+", ErrorMessage = "Invalid value")]
        public string RelationType { get; set; }
    }
}

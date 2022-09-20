using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Models
{
    public class Relation
    {
        [Key]
        public int RelationId { get; set; }

        [RegularExpression(@"\D+", ErrorMessage = "Invalid value")]
        public string RelationType { get; set; }
    }
}

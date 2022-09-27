using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Models
{
    public class Relation
    {
        [Key]
        public int RelationId { get; set; }

        public int? PersonId1 { get; set; }
        public Person person1 { get; set; }

        public int? PersonId2 { get; set; }
        public Person person2 { get; set; }

        [RegularExpression(@"\D+", ErrorMessage = "Invalid value")]
        public string RelationType { get; set; }

        public override string ToString()
        {
            return $"RelationId: {RelationId}" +
                   $"PersonId1: {PersonId1}" +
                   $"Person1: {person1.FirstName}" +
                   $"PersonId2: {PersonId2}" +
                   $"Person2: {person2.FirstName}" +
                   $"Relation: {RelationType}";

        }

    }
}

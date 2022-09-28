using System.ComponentModel.DataAnnotations;

namespace PracticeProject.Models
{
    public class Relation
    {
        [Key]
        public int RelationId { get; set; }

        [Required]
        public int PersonId1 { get; set; }
        public Person? Person1 { get; set; }

        [Required]
        public int PersonId2 { get; set; }
        public Person? Person2 { get; set; }

        [Required]
        [RegularExpression(@"\D+", ErrorMessage = "Invalid value")]
        public string RelationType { get; set; }

        //public override string ToString()
        //{
        //    return $"RelationId: {RelationId}" +
        //           $"PersonId1: {PersonId1}" +
        //           $"Person1: {Person1}" +
        //           $"PersonId2: {PersonId2}" +
        //           $"Person2: {Person2}" +
        //           $"Relation: {RelationType}";
        //}

    }
}

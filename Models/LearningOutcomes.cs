using System.ComponentModel.DataAnnotations;

namespace BolognaInformationSystem.Models
{
    public class LearningOutcome
    {
        [Key]
        public int OutcomeID { get; set; }
        public int CourseID { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }
    }

}

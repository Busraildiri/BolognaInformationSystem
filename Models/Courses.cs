namespace BolognaInformationSystem.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public int? AssignedInstructorID { get; set; }
        public User AssignedInstructor { get; set; }
    }
}

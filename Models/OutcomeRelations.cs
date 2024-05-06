namespace BolognaInformationSystem.Models
{
    public class OutcomeRelation
    {
        public int OutcomeID { get; set; }
        public int ProgramOutcomeID { get; set; }
        public int RelationDegree { get; set; }
        public LearningOutcome LearningOutcome { get; set; }
        public ProgramOutcome ProgramOutcome { get; set; }
    }

}

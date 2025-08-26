namespace hr_management_backend.Models
{
    public enum RecruitmentStatus
    {
        Pending,
        Accepted,
        Rejected
    }

    public class Recruitment
    {
        public int Id { get; set; }
        public string CandidateName { get; set; }
        public int JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }
        public DateTime AppliedOn { get; set; }
        public RecruitmentStatus Status { get; set; }
    }
}

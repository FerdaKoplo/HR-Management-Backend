namespace hr_management_backend.DTOs.Recruitment
{
    public class RecruitmentDetailDTO
    {
        public int Id { get; set; }
        public string CandidateName { get; set; }
        public DateTime AppliedOn { get; set; }
        public string Status { get; set; }

        public int JobTitleId { get; set; }
        public string JobTitleName { get; set; }
    }
}

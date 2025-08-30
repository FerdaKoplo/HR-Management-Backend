using AutoMapper;
using hr_management_backend.DTOs.Department;
using hr_management_backend.DTOs.Evaluation;
using hr_management_backend.Models;

namespace hr_management_backend.Profiles
{
    public class EvaluationProfile : Profile
    {
        public EvaluationProfile()
        {
            CreateMap<CreateEvaluationDTO, Evaluation>();
            CreateMap<UpdateEvaluationDTO, Evaluation>();
            CreateMap<EvaluationDTO, Evaluation>();
            CreateMap<EvaluationDetailDTO, Evaluation>();

            CreateMap<Evaluation, CreateEvaluationDTO>();
            CreateMap<Evaluation, UpdateEvaluationDTO>();
            CreateMap<Evaluation, EvaluationDTO>();
            CreateMap<Evaluation, EvaluationDetailDTO>();
        }
    }
}

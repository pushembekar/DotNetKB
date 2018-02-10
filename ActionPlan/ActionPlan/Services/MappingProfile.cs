using AutoMapper;
using ActionPlan.Entities;
using ActionPlan.Models.PlanOfActionViewModels;
using System.Linq;

namespace ActionPlan.Services
{
    /// <summary>
    /// AutoMapper mapping profile. This maps the Entities objects with Models -> ViewModels
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Creates mapping between various entities and view models
        /// </summary>
        public MappingProfile()
        {
            // Mapping from AuthSystem model to POAM view model
            CreateMap<AuthSystem, POAMViewModel>();
            // Mapping from DelayReason model to POAM view model
            CreateMap<DelayReason, POAMViewModel>();
            // Mapping from ResponsiblePOC model to POAM view model
            CreateMap<ResponsiblePOC, POAMViewModel>();
            // Mapping from RiskLevel model to POAM view model
            CreateMap<RiskLevel, POAMViewModel>();
            // Mapping from Status model to POAM view model
            CreateMap<Status, POAMViewModel>();
            // Mapping from Weakness model to POAM view model
            CreateMap<Weakness, POAMViewModel>();
            // Mapping from POAM model to POAM view model
            CreateMap<POAM, POAMViewModel>()
                .ForMember(dest => dest.AuthSystem, opt => opt.MapFrom(src => src.AuthSystem.Name))
                .ForMember(dest => dest.DelayReason, opt => opt.MapFrom(src => src.DelayReason.Name))
                .ForMember(dest => dest.ResponsiblePOCs, opt => opt.MapFrom(src => string.Join(", ", src.ResponsiblePOCs.Select(sel => sel.Name))))
                .ForMember(dest => dest.RiskLevel, opt => opt.MapFrom(src => src.RiskLevel.Description))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Name))
                .ForMember(dest => dest.OriginalRecommendation, opt => opt.MapFrom(src => src.Weakness.OriginalRecommendation))
                .ForMember(dest => dest.Risk, opt => opt.MapFrom(src => src.Weakness.Risk));
        }
    }
}

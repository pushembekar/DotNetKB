using AutoMapper;
using ActionPlan.Entities;
using ActionPlan.Models.PlanOfActionViewModels;

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
            CreateMap<POAM, POAMViewModel>();
        }
    }
}

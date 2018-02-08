using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            CreateMap<Entities.AuthSystem, Models.PlanOfActionModels.POAM>();
            // Mapping from DelayReason model to POAM view model
            CreateMap<Entities.DelayReason, Models.PlanOfActionModels.POAM>();
            // Mapping from ResponsiblePOC model to POAM view model
            CreateMap<Entities.ResponsiblePOC, Models.PlanOfActionModels.POAM>();
            // Mapping from RiskLevel model to POAM view model
            CreateMap<Entities.RiskLevel, Models.PlanOfActionModels.POAM>();
            // Mapping from Status model to POAM view model
            CreateMap<Entities.Status, Models.PlanOfActionModels.POAM>();
            // Mapping from Weakness model to POAM view model
            CreateMap<Entities.Weakness, Models.PlanOfActionModels.POAM>();
            // Mapping from POAM model to POAM view model
            CreateMap<Entities.POAM, Models.PlanOfActionModels.POAM>();
        }
    }
}

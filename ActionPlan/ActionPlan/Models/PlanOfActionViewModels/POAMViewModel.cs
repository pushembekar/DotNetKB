using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActionPlan.Models.PlanOfActionViewModels
{
    /// <summary>
    /// The main view model for the application.
    /// </summary>
    public class POAMViewModel
    {
        [Key]
        // Primary key of the collection
        public Guid ID { get; set; }

        [Required]
        // System for which the POAM has been created
        public string AuthSystem { get; set; }

        // The number provided in the POAM excel file
        public int Number { get; set; }

        // The POAM ID from CSAM
        public string CSAMPOAMID { get; set; }

        // The Control ID of the security vulnerability. 
        // This is usually the control number from the DOT compendium or CIS benchmark 
        // or a reference number from a third party entity
        public string ControlID { get; set; }

        // Risk Level as determined during the security assessment of the application/system
        public string RiskLevel { get; set; }

        // Current status of the POAM
        public string Status { get; set; }

        // Delay reason for the POAM (if any)
        public string DelayReason { get; set; }

        [Required]
        // Original recommendation provided during the security assessment F&R
        public string OriginalRecommendation { get; set; }

        // Detailed risk provided during the security assessment F&R
        public string Risk { get; set; }

        [Required]
        // Recommendation made during the security assessment F&R
        public string Recommendation { get; set; }

        // List of POCs responsible for the POAM
        public string ResponsiblePOCs { get; set; }

        // Dollar amount (Resources required)
        public decimal ResourcesRequired { get; set; }

        // Justification of the cost
        public string CostJustification { get; set; }

        // Date the POAM is scheduled to be completed
        public string ScheduledCompletionDate { get; set; }

        // Date the POAM item is planned to start
        public string PlannedStartDate { get; set; }

        // Date the POAM work actually started
        public string ActualStartDate { get; set; }

        // Date the POAM item work was completed
        public string ActualFinishDate { get; set; }

    }
}

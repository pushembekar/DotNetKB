using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Display(Name = "System")]
        // System for which the POAM has been created
        public string AuthSystem { get; set; }

        [Display(Name = "Line #")]
        // The number provided in the POAM excel file
        public int Number { get; set; }

        [Display(Name = "CSAM POA&M ID")]
        // The POAM ID from CSAM
        public string CSAMPOAMID { get; set; }

        [Display(Name = "Control ID(s)")]
        // The Control ID of the security vulnerability. 
        // This is usually the control number from the DOT compendium or CIS benchmark 
        // or a reference number from a third party entity
        public string ControlID { get; set; }

        [NotMapped]
        // Flag to store whether the control id is trunctated on the view or not
        public bool IsControlIDTruncated { get; set; }

        [Display(Name = "Risk Level")]
        // Risk Level as determined during the security assessment of the application/system
        public string RiskLevel { get; set; }

        [Display(Name = "Status")]
        // Current status of the POAM
        public string Status { get; set; }

        [Display(Name = "Delay Reason")]
        // Delay reason for the POAM (if any)
        public string DelayReason { get; set; }

        [Display(Name = "Original Recommendation")]
        // Original recommendation provided during the security assessment F&R
        public string OriginalRecommendation { get; set; }

        [NotMapped]
        // Flag to store whether the original recommendation is trunctated on the view or not
        public bool IsOriginalRecommendationTruncated { get; set; }

        [Display(Name = "Risk")]
        // Detailed risk provided during the security assessment F&R
        public string Risk { get; set; }

        [NotMapped]
        // Flag to store whether the risk is trunctated on the view or not
        public bool IsRiskTruncated { get; set; }

        [Display(Name ="Recommendation")]
        // Recommendation made during the security assessment F&R
        public string Recommendation { get; set; }

        [NotMapped]
        // Flag to store whether the recommendation is trunctated on the view or not
        public bool IsRecommendationTruncated { get; set; }

        [Display(Name ="Responsible POCs")]
        // List of POCs responsible for the POAM
        public string ResponsiblePOCs { get; set; }

        [Display(Name = "Resources Required")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        // Dollar amount (Resources required)
        public decimal ResourcesRequired { get; set; }

        [Display(Name ="Cost Justification")]
        // Justification of the cost
        public string CostJustification { get; set; }

        [Display(Name ="Scheduled Completion")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MMM yyyy}", ApplyFormatInEditMode = true, NullDisplayText = "TBD")]
        // Date the POAM is scheduled to be completed
        public DateTime? ScheduledCompletionDate { get; set; }

        [Display(Name ="Planned Start")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MMM yyyy}", ApplyFormatInEditMode = true, NullDisplayText = "TBD")]
        // Date the POAM item is planned to start
        public DateTime? PlannedStartDate { get; set; }

        [Display(Name ="Planned Finish")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MMM yyyy}", ApplyFormatInEditMode = true, NullDisplayText = "TBD")]
        // Date the POAM item is planned to finish
        public DateTime? PlannedFinishDate { get; set; }

        [Display(Name ="Actual Start")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MMM yyyy}", ApplyFormatInEditMode = true, NullDisplayText = "TBD")]
        // Date the POAM work actually started
        public DateTime? ActualStartDate { get; set; }

        [Display(Name ="Actual Finish")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MMM yyyy}", ApplyFormatInEditMode = true, NullDisplayText = "TBD")]
        // Date the POAM item work was completed
        public DateTime? ActualFinishDate { get; set; }

    }
}

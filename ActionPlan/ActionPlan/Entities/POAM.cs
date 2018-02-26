using ActionPlan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ActionPlan.Entities
{
    /// <summary>
    /// The main model for the application. This is where the structure of the POAM table will be defined
    /// </summary>
    public class POAM
    {
        [Key]
        // Primary key of the collection
        public Guid ID { get; set; }

        [Required]
        // System for which the POAM has been created
        public AuthSystem AuthSystem { get; set; }

        // The number provided in the POAM excel file
        public int Number { get; set; }

        // The POAM ID from CSAM
        public string CSAMPOAMID { get; set; }

        // The Control ID of the security vulnerability. 
        // This is usually the control number from the DOT compendium or CIS benchmark 
        // or a reference number from a third party entity
        public string ControlID { get; set; }

        // Risk Level as determined during the security assessment of the application/system
        public RiskLevel RiskLevel { get; set; }

        // Current status of the POAM
        public Status Status { get; set; }

        // Delay reason for the POAM (if any)
        public DelayReason DelayReason { get; set; }

        // Weakness found during the security assessment F&R
        public Weakness Weakness { get; set; }

        // Recommendation made during the security assessment F&R
        public string Recommendation { get; set; }

        // List of POCs responsible for the POAM
        public virtual IList<ResponsiblePOC> ResponsiblePOCs { get; set; }

        [DataType(DataType.Currency)]
        [DefaultValue(100)]
        // Dollar amount (Resources required)
        public decimal ResourcesRequired { get; set; }

        // Justification of the cost
        public string CostJustification { get; set; }

        // Date the POAM is scheduled to be completed
        public DateTime? ScheduledCompletionDate { get; set; }

        // Date the POAM item is planned to start
        public DateTime? PlannedStartDate { get; set; }

        // Date the POAM item is planned to finish
        public DateTime? PlannedFinishDate { get; set; }

        // Date the POAM work actually started
        public DateTime? ActualStartDate { get; set; }

        // Date the POAM item work was completed
        public DateTime? ActualFinishDate { get; set; }

        // Date the POAM was created in the ActionPlan application 
        // (not to be confused with the POAM creation date from security assessment team)
        public DateTime CreateDate { get; set; }

        // User who created the POAM. Since only registered users are going to be allowed
        // to create the POAM, this property is not of a string type, but of the type = ApplicationUser
        public ApplicationUser CreatedBy { get; set; }
    }
}

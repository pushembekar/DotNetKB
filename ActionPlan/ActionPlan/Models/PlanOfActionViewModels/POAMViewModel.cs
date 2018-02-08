﻿using System;
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
        // Weakness found during the security assessment F&R
        public string Weakness { get; set; }

        [Required]
        // Recommendation made during the security assessment F&R
        public string Recommendation { get; set; }

        // List of POCs responsible for the POAM
        public string ResponsiblePOCs { get; set; }

    }
}
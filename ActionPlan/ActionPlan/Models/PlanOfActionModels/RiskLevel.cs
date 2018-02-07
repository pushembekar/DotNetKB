﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActionPlan.Models.PlanOfActionModels
{
    /// <summary>
    /// Denotes the risk level of the POAM item: VL, L, M, H, VH
    /// </summary>
    public class RiskLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // ID of the risk level (primary key). Will need to be provided by the initializer or seeder
        public int ID { get; set; }

        [Required]
        [MaxLength(2)]
        // Name of the risk level: VL, L, M, H, VH
        public string Name { get; set; }

        [MaxLength(10)]
        // Description of the risk level: Very Low, Low, Medium, High, Very High
        public string Description { get; set; }
    }
}

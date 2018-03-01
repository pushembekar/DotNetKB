using System;
using System.ComponentModel.DataAnnotations;

namespace ActionPlan.Entities
{
    /// <summary>
    /// Describes the POCs responsible for the POAM
    /// </summary>
    public class ResponsiblePOC
    {
        [Key]
        // ID of the Responsible POC
        public Guid ID { get; set; }

        [Required]
        // Name of the POC
        public string Name { get; set; }

        // Decription of the POC
        public string Description { get; set; }
    }
}

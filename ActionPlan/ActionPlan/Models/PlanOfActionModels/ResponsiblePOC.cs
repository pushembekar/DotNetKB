using System.ComponentModel.DataAnnotations;

namespace ActionPlan.Models.PlanOfActionModels
{
    /// <summary>
    /// Describes the POCs responsible for the POAM
    /// </summary>
    public class ResponsiblePOC
    {
        [Key]
        // ID of the Responsible POC
        public int ID { get; set; }

        [Required]
        // Name of the POC
        public string Name { get; set; }

        // Decription of the POC
        public string Description { get; set; }
    }
}

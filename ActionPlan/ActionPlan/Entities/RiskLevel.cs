using System.ComponentModel.DataAnnotations;

namespace ActionPlan.Entities
{
    /// <summary>
    /// Denotes the risk level of the POAM item: VL, L, M, H, VH
    /// </summary>
    public class RiskLevel
    {
        [Key]
        // ID of the risk level (primary key).
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

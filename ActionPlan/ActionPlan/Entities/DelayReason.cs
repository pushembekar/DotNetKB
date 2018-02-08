using System.ComponentModel.DataAnnotations;

namespace ActionPlan.Entities
{
    /// <summary>
    /// Denotes the Delay Reason of the POAM
    /// </summary>
    public class DelayReason
    {
        [Key]
        // ID of the Delay Reason
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        // Name of the Delay Reason
        public string Name { get; set; }

        [MaxLength(40)]
        // Description of the Delay Reason
        public string Description { get; set; }
    }
}

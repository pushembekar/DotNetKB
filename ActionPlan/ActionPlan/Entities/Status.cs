using System.ComponentModel.DataAnnotations;

namespace ActionPlan.Entities
{
    /// <summary>
    /// Describes the current status of the POAM
    /// </summary>
    public class Status
    {
        [Key]
        // ID of the status (primary key)
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        // Name of the status: Planned/Pending, Existing Risk Acceptance etc.
        public string Name { get; set; }

        [MaxLength(40)]
        // Description of the status
        public string Description { get; set; }
    }
}

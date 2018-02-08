using System.ComponentModel.DataAnnotations;

namespace ActionPlan.Entities
{
    /// <summary>
    /// Information of system that is undergoing security authorization
    /// </summary>
    public class AuthSystem
    {
        [Key]
        // ID of the system (primary key)
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        // Name of the system
        public string Name { get; set; }

        [MaxLength(40)]
        // Description of the system
        public string Description { get; set; }
    }
}

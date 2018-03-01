using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActionPlan.Entities
{
    /// <summary>
    /// Describes the Weakness that was found during the security assessment
    /// Usually has a "Original Recommendation" section and a "Risk" section
    /// </summary>
    public class Weakness
    {
        [Key]
        // ID of the weakness (primary key)
        public Guid ID { get; set; }

        [Required]
        // Original recommendation of the weakness
        public string OriginalRecommendation { get; set; }

        // The Risk as noted during the security assessment F&R
        public string Risk { get; set; }
    }
}

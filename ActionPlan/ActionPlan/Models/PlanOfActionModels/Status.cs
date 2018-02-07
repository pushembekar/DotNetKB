using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ActionPlan.Models.PlanOfActionModels
{
    /// <summary>
    /// Describes the current status of the POAM
    /// </summary>
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // ID of the status (primary key). Will need to be provided by the initializer or seeder
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

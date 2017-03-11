using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace WebApplication.Models {
    public class Need {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int OccupantId { get; set; }
        public Occupant Occupant { get; set; }
        [Required]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        [DefaultValue("CURRENT_TIMESTAMP")]
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
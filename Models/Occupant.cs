using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models {
    public class Occupant {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        [DefaultValue("CURRENT_TIMESTAMP")]

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Active { get; set; }
        [Required]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<OccupantNeed> OccupantNeeds { get; set; }
    }
}
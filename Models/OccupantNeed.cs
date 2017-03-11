using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebApplication.Models {
    public class OccupantNeed {
        public int Id { get; set; }
        [Required]
        public int OccupantId { get; set; }
        public Occupant Occupant { get; set; }
        [Required]
        public int NeedId { get; set; }
        public Need Need { get; set; }
        [Required]
        [DefaultValue(true)]
        public bool Active { get; set; }
        public string Notes { get; set; }
        [DefaultValue("CURRENT_TIMESTAMP")]
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
using HomefulAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomefulAPI.ViewModels.Needs
{
    public class CreateNeedViewModel
    {
        [Required]
        [Description("Need description")]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public int LocationID { get; set; }
        public Location Location { get; set; }
    }
}
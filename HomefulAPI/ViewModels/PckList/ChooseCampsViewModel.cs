using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomefulAPI.ViewModels.PckList
{
    public class ChooseCampsViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}
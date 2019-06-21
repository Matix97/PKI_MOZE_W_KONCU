using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNetCoreSqlDb.Models
{
    public class SignUpModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        // This property will hold a state, selected by user
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }
        // This property will hold all available states for selection
        public IEnumerable<SelectListItem> States { get; set; }

    }

}
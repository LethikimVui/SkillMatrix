using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.Models
{
    public class AddEmployeeModel
    {
        [Required(ErrorMessage = "Please enter SAP")]
        public string Sap { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Superior Email")]
        public string SuperiorEmail { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Workcell")]
        public string Workcell { get; set; }
        [Required(ErrorMessage = "Please enter Position")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Please enter Sector")]
        public int? Sector { get; set; }
        [Required(ErrorMessage = "Please enter Image Link")]
        public string Image { get; set; }
    }
}

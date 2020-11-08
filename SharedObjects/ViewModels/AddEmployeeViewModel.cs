using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class AddEmployeeViewModel
    {
        [Required(ErrorMessage = "Please enter SAP")]
        [Display(Name = "Employee SAP")]
        public string Sap { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Superior Email")]
        [Display(Name = "Superior Email")]
        public string SuperiorEmail { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Workcell")]
        [Display(Name = "Workcell")]

        public string Workcell { get; set; }
        [Required(ErrorMessage = "Please enter Position")]
        [Display(Name = "Position")]

        public string Position { get; set; }
        [Required(ErrorMessage = "Please enter Sector")]
        [Display(Name = "Sector")]

        public int? Sector { get; set; }
        [Required(ErrorMessage = "Please enter Image Link")]
        [Display(Name = "Image")]

        public IFormFile Image { get; set; }
    }
}

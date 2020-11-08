using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VEmployee
    {
        [Display(Name = "Employee SAP")]
        public string Sap { get; set; }
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Display(Name = "Superior Email")]
        public string SuperiorEmail { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Workcell")]
        public string Workcell { get; set; }
        [Display(Name = "Position")]
        public string Position { get; set; }
        [Display(Name = "Sector")]
        public string Sector { get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; }
        [Display(Name = "Total Weight")]
        public long? TotalWeight { get; set; }
        [Display(Name = "Total Assesment")]
        public long? TotalAssesment { get; set; }
        [Display(Name = "Final Assessment Score")]
        public decimal? FinalAssessmentScore { get; set; }
    }
}

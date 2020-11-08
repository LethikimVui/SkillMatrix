using System;
using System.Collections.Generic;

namespace APISkillMatrix.Models
{
    public partial class Employee
    {
        public string Sap { get; set; }
        public string Name { get; set; }
        public string SuperiorEmail { get; set; }
        public string Email { get; set; }
        public string Workcell { get; set; }
        public string Position { get; set; }
        public int? Sector { get; set; }
        public string Image { get; set; }
        public long? TotalWeight { get; set; }
        public long? TotalAssesment { get; set; }
        public decimal? FinalAssessmentScore { get; set; }
        public byte? Status { get; set; }
    }
}

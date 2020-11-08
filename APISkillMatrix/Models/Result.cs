using System;
using System.Collections.Generic;

namespace APISkillMatrix.Models
{
    public partial class Result
    {
        public int Id { get; set; }
        public string Sap { get; set; }
        public string Topic { get; set; }
        public int? Sector { get; set; }
        public int? EvalScore { get; set; }
        public int? AssesScore { get; set; }
        public byte? Status { get; set; }
    }
}

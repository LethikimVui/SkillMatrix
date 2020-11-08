using System;
using System.Collections.Generic;

namespace APISkillMatrix.Models
{
    public partial class SkillMatrixContent
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Trainer { get; set; }
        public int? Weight { get; set; }
        public string Evaluator { get; set; }
        public int? Sector { get; set; }
        public byte? Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VSkillMatrix
    {
        public string Topic { get; set; }
        public string Trainer { get; set; }
        public int? Weight { get; set; }
        public string Evaluator { get; set; }

        public int? EvalScore { get; set; }
        public int? AssesScore { get; set; }
        
    }
}

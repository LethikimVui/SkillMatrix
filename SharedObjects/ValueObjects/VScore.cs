using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VScore
    {
       
    public string Sap { get; set; }
        public string Topic { get; set; }
      
        public int? Weight { get; set; }
        public string Evaluator { get; set; }
     
        public int? EvalScore { get; set; }
        public int? AssesScore { get; set; }
     
    }

}

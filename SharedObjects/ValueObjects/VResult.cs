using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VResult
    {
        public int id { get; set; }
        public string NTID { get; set; }
        public string Topic { get; set; }
        public int? evalScore { get; set; }
        public int? assessScore { get; set; }
        public string latestEvaluatorName { get; set; }
        public DateTime? modifiedDate { get; set; }
        
    }
}

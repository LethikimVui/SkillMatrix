using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VSearchResult
    {
        public string Sap { get; set; }
        public string Name { get; set; }
        public string SuperiorEmail { get; set; }
        public string Email { get; set; }
        public string Workcell { get; set; }
        public string Position { get; set; }
        public string Sector { get; set; }
        public string Image { get; set; }
        public long? TotalWeight { get; set; }
        public long? TotalAssesment { get; set; }
    }
}

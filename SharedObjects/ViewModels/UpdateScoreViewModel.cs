using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class UpdateScoreViewModel
    {
        public int Id { get; set; }
        public string Sap { get; set; }
        public int EvalScore { get; set; }
        public int AssesScore { get; set; }
        public int LatestEvaluatorId { get; set; }

    }
}

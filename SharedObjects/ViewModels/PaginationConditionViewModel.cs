using System;
using System.Collections.Generic;
using System.Text;

namespace SharedObjects.ViewModels
{
   public class PaginationConditionViewModel
    {
        public string Input { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}

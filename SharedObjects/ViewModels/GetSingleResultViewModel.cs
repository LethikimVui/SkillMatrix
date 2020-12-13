using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class GetSingleResultViewModel
    {
        public string NTID { get; set; }
        public int TopicId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.Models
{
    public class UpdateEmployeeModel
    {
        [Required]
        public string SAP { get; set; }
        [Required]
        public string Image { get; set; }
    }
}

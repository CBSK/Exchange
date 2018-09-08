using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Model.Models
{
    [Table("CustomsBroker")]
    public class CustomsBroker
    {
        [Key]
        public int customsBrokerID { get; set; }
        public string CustomsBrokerName { get; set; }
        public string TaxNumber { get; set; }
        public int? TaxBranch { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsVoid { get; set; }
    }
}

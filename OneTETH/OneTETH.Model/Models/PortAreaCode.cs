using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Model.Models
{
    [Table("PortAreaCode")]
    public class PortAreaCode
    {
        [Key]
        public int AreaCode { get; set; }
        public string AreaName { get; set; }
        public string AbbreviateName { get; set; }
        public string DepartID { get; set; }
        public string EmailAddress { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string PaymentPort { get; set; }
        public string ExpReleaseIndicator { get; set; }
        public string ExpLoadIndicator { get; set; }
        public string ImpReleaseIndicator { get; set; }
        public string ImpDischargeIndicator { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Model.Models
{
    public class ReportFilter
    {
        [Required]
        public DateTime StartSubmissionDate { get; set; }

        [Required]
        public DateTime EndSubmissionDate { get; set; }

        public string StartSubmissionDateStr { get; set; }
        public string EndSubmissionDateStr { get; set; }

        public string BrokerName { get; set; }
        public string InvoiceNo { get; set; }
        public string DeclarationNo { get; set; }
        public string StatusCode { get; set; }
        public string Compensation { get; set; }
        public string ModeOfTransport { get; set; }        
    }
}

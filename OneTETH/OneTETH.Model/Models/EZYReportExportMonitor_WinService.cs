using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Model.Models
{
    [Table("EZYReportExportMonitor_WinService")]
    public class EZYReportExportMonitor_WinService
    {
        [Key]
        public long EZYReportExportMonitorID { get; set; }
        public string EmailAddress { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime PStartSubmissionDate { get; set; }
        public DateTime PEndSubmissionDate { get; set; }
        public string PCustomBrokerName { get; set; }
        public string PPurchaseCountryCode { get; set; }
        public string PInvoiceNumber { get; set; }
        public string PDeclarationNumber { get; set; }
        public string PStatus { get; set; }
        public string PModeOfTransport { get; set; }
        public string PCompensation { get; set; }
        public bool? IsFileGenerated { get; set; }
        public bool? IsEmailSent { get; set; }     
        public DateTime? AddOn { get; set; }       
        public DateTime? ModOn { get; set; }
    }
}

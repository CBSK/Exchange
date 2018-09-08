using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Model.Models.DTO
{
    public class EzyExportPermitDTO
    {
        public Guid PermitUuid { get; set; }
        public Guid InvoiceDuuid { get; set; }
        public Guid InvoiceHuuid { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal ItemNumber { get; set; }
        public string PermitNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public string PermitIssueAuthority { get; set; }
        public string DisplayIssueDate { get; set; }
    }
}

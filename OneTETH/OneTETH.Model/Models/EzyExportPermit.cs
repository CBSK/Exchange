using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneTETH.Model.Models
{
    [Table("EzyExportPermit")]
    public class EzyExportPermit
    {
        [Key]
        public Guid PermitUuid { get; set; }
        public Guid InvoiceDuuid { get; set; }
        public Guid InvoiceHuuid { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal ItemNumber { get; set; }
        public string PermitNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public string PermitIssueAuthority { get; set; }
    }
}

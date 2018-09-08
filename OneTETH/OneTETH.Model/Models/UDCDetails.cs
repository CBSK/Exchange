using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Model.Models
{
    [Table("Udc_Details")]
    public class UdcDetails
    {
        [Column("Udc_DId", Order = 0), Key]
        public int UdcDId { get; set; }
        [Column("Udc_MId", Order = 1), Key]
        public int UdcMId { get; set; }
        [Column("Udc_DCode")]
        public string UdcDCode { get; set; }
        [Column("Udc_DDesc")]
        public string UdcDDesc { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDel { get; set; }
        public int? AddBy { get; set; }
        public DateTime? AddOn { get; set; }
        public int? ModBy { get; set; }
        public DateTime? ModOn { get; set; }
    }
}

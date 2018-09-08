using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Model.Models
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool AllowsBilling { get; set; }
        public bool AllowsShipping { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
        public int NumericIsoCode { get; set; }
        public bool SubjectToVat { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public bool LimitedToStores { get; set; }
        public string Edimapping { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsVoid { get; set; }
        public int? AddBy { get; set; }
        public DateTime? AddOn { get; set; }
        public int? ModBy { get; set; }
        public DateTime? ModOn { get; set; }
    }
}

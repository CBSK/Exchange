using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Model.Models.DTO
{
    public class FTPFileDataListDTO
    {
        public int fId { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string ContentType { get; set; }
        public decimal? FileSize { get; set; }
        public byte[] FileData { get; set; }
        public DateTime? FileLastModified { get; set; }
        public int? psLocation { get; set; }
        public bool? isProcessed { get; set; }
        public DateTime? ProcessDate { get; set; }
        public bool? isActive { get; set; }
        public bool? isVoid { get; set; }
        public DateTime? AddOn { get; set; }
        public int? AddBy { get; set; }
        public DateTime? ModOn { get; set; }
        public int? ModBy { get; set; }
    }
}

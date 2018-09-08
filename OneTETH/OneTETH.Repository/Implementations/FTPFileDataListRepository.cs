using OneTETH.Model.Models;
using OneTETH.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Repository.Implementations
{
    public class FTPFileDataListRepository: IFTPFileDataListRepository
    {
        private OneTEDBContext _context;
        public FTPFileDataListRepository(OneTEDBContext context)
        {
            _context = context;
        }

        public FTPFileDataList GetFileData(int Id)
        {
            var ftpFile = (from file in _context.FTPFileDataList
                           where file.fId == Id
                           select file
                       ).FirstOrDefault();

            return ftpFile;
        }
    }
}

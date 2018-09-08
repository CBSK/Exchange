using OneTETH.Model.Models;
using OneTETH.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTETH.Repository.Implementations
{
    public class CustomsResponseDetailRepository: ICustomsResponseDetailRepository
    {
        private OneTEDBContext _context;
        public CustomsResponseDetailRepository(OneTEDBContext context)
        {
            _context = context;
        }

        public List<CustomsResponseDetail> GetCustomsResponseDetails(string decNo)
        {
            return (from cr in _context.CustomsResponseDetail
                    where cr.DeclarationNumber == decNo && cr.MessageType != "XDCA"
                    select cr).Distinct().ToList();
        }
    }
}

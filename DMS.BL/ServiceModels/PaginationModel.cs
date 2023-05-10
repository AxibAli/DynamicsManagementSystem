using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BL.ServiceModels
{
    public class PaginationModel
    {
        public int CurrentPage { get; set; }
        public decimal TotalPages { get; set; }
        public object Data { get; set; }
    }
}

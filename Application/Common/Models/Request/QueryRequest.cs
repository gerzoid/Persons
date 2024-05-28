using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Common.Models
{
    public class QueryRequest
    {
        public int CountPerPage { get; set; }
        public List<Filters> Filters { get; set; }
        public List<Sorts> Sorts { get; set; }
    }
}

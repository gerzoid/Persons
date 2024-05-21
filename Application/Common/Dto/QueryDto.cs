using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dto
{
    public class QueryDto
    {
        public int CountPerPage {  get; set; }
        public List<Filters> Filters { get; set; }
        public List<Sorts> Sorts { get; set; }
    }
}

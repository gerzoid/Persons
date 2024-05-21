using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dto
{
    public class Filters
    {
        public string Field {  get; set; }
        public string Value { get; set; }
        public string Operator { get; set; }
    }
}

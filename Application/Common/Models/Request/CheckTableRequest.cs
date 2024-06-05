using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class CheckTableRequest
    {
        public string tableName { get; set; }
        public string shema { get; set; }
        public string database { get; set; }
    }
}

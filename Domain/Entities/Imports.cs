using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Imports
    {
        public DateTime date_update { get; set; }
        public DateTime date_import { get; set; }
        public int count_columns{ get; set; }
        public int count_rows { get; set; }
        public int import_id { get; set; }
        public int status { get; set; }
        public DateTime date_status_update { get; set; }
    }
}

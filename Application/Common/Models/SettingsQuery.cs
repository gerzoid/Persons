using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class SettingsQuery
    {
        public int Top { get; set; }
        public string[] Columns { get; set; }
        public string[] ColumnsOrder { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class PersonsRequest
    {
        public int TableId { get; set; }
        public int? PerPage { get; set; }
        public int? Page { get; set; }
    }
}

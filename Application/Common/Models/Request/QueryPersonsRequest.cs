﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Dto;

namespace Application.Common.Models
{
    public class QueryPersonsRequest
    {
        public int TableId {  get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public List<Filters> Filters { get; set; }
        public List<Sorts> Sorts { get; set; }
    }
}
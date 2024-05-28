﻿using Mapster;
using System.ComponentModel.DataAnnotations;

namespace Application.Common.Models
{
    public class PersonsResponse
    {
        public int TableId { get; set; }
        public List<Column> Columns { get; set; }

    }
}

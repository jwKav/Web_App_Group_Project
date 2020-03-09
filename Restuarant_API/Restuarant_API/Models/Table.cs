using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_API.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public int? TableCategoryId { get; set; }
        public bool IsBooked { get; set; } = false;
        public TableCategory TableCategory { get; set; }

    }
}

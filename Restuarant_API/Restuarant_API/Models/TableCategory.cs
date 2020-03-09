using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_API.Models
{
    public class TableCategory
    {
        public int TableCategoryId { get; set; }
        public int TableCapacity { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}

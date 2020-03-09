using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Restaurant_API.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        
        public DateTime BookingDate { get; set; }

        public int? CustomerId { get; set; }
        public int? TableId { get; set; }
        public Customer Customer { get; set; }
        public Table Table { get; set; }

    }
}

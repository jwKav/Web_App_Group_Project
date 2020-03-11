﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_API.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        [Range(0,12)]
        public int GroupCount { get; set; }
        public int? BookingId { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
            = new List<Booking>();
    }
}

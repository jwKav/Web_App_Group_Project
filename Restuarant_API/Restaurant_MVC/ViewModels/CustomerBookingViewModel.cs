using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Restaurant_API.Models;

namespace Restaurant_MVC.ViewModels
{
    public class CustomerBookingViewModel
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        [Range(0, 12)]
        public int GroupCount { get; set; }
        public virtual ICollection<Table> Tables { get; set; } = new List<Table>();
        public DateTime BookingDate { get; set; }

    }
}

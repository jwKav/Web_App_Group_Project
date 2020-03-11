using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant_API.Models;

namespace Restaurant_API.Services
{
    public interface IBookingInfoRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int customerId, bool includeBookingDetails);
        IEnumerable<Booking> GetBookings();
        Booking GetBooking(int customerId);

    }
}

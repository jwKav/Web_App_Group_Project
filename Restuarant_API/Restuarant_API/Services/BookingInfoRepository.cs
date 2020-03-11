using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Restaurant_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Restaurant_API.Services
{
    public class BookingInfoRepository : IBookingInfoRepository
    {
        private readonly RestaurantDbContext _context;
        public BookingInfoRepository(RestaurantDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }
        public Customer GetCustomer(int customerId, bool includeBookingDetails)
        {
            if (includeBookingDetails)
            {
                return _context.Customers.Include(c => c.Booking)
                    .Where(c => c.CustomerId == customerId).FirstOrDefault();
            }
            return _context.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
        }
        public IEnumerable<Booking> GetBookings()
        {
            throw new NotImplementedException();
        }
        public Booking GetBooking(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}

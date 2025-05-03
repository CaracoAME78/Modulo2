using ReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaRestaurant.Repositories
{
    internal interface IReservationRepository : IRepository<Reservation>
    {
        List<Reservation> GetReservationByDate(DateTime date);
        List<Reservation> GetReservationByCustomer(string customerId);
    }
}

using ReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaRestaurant.Services
{
    internal interface IReservationService
    {
        bool CreateResevation(Reservation reservation);
        bool UpdateResevation(Reservation reservation);
        bool DeleteResevation(Reservation reservation);
        List<Reservation> GetAllReservationsByDate(DateTime date);
        Reservation GetReservationById(int id);
    }
}

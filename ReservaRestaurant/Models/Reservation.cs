using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaRestaurant.Models
{
    internal class Reservation
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TableId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int PartySize {  get; set; }
        public string SpecialRequest {  get; set; }
        public ReservationStatus Status { get; set; }

    }
}

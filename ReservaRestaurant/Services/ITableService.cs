using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaRestaurant.Services
{
    internal interface ITableService
    {
        List<Table> GetAvailableTables(DateTime date, TimeSpan time);

    }
}

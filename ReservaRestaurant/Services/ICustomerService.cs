using ReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaRestaurant.Services
{
    internal interface ICustomerService
    {
        Customer GetCustumerById(int id);
        List<Customer> GetAll();
    }
}

using ReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaRestaurant.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        private List<Customer> _customers = new List<Customer>;
        private int _nextId = 1;

         void IRepository<Customer>.Add(Customer entity)
        {
            entity.Id = ++_nextId;
        }

         void IRepository<Customer>.Delete(Customer entity)
        {
            _customers.Remove(entity);
        }

         List<Customer> IRepository<Customer>.GetAll()
        {
            return _customers;
        }

         Customer ICustomerRepository.GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

         Customer IRepository<Customer>.GetById(int id)
        {
            return _customers.FirstOrDefault(x=>x, id= id);
        }

         Customer ICustomerRepository.GetByPhoneNumber(string phoneNumber)
        {
            return _customers.FirstOrDefault(x => x, phoneNumber == phoneNumber);
        }

         void IRepository<Customer>.Update(Customer entity)
        {
            var index = _customers.FindIndex(x => x, Id = id);
            if (index != -1)
            {
                _customers[index] = entity;
            }

        }
    }
}

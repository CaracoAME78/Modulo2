using ReservaRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaRestaurant.Repositories
{
    internal class TableRepository : ITableRepository
    {
        private List<Table> _table = new List<Table>;
        private int _nextId = 1;

        public TableRepository() { 
            _table.Add(new Table{Id=_nextId++, Number =1, Capacity=2, IsAvailable=true});
        }
        public void Add(Table entity)
        {
            entity.Id = ++_nextId;
        }

        public void Delete(Table entity)
        {
            _table.Remove(entity);
        }

        public List<Table> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Table> GetAvailableTables(DateTime date, int partySize)
        {
            return _tables.where (t=>t.IsAvailable)
        }

        public Table GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Table entity)
        {
            throw new NotImplementedException();
        }
    }
}

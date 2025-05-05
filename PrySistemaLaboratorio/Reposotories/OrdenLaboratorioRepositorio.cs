using PrySistemaLaboratorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Reposotories
{

    internal class OrdenLaboratorioRepositorio : IOrdenLaboratorioRepositorio
    {
        private List<OrdenLaboratorio> _ordenes = new List<OrdenLaboratorio>();
        private static Dictionary<string, int> correlativos = new Dictionary<string, int>();

        public void Add(OrdenLaboratorio entity)
        {
            var hoy = DateTime.Now;
            string clave = hoy.ToString("yyMMdd");

            if (!correlativos.ContainsKey(clave))
                correlativos[clave] = 1;
            else
                correlativos[clave]++;

            entity.IdOrden = $"{clave}{correlativos[clave]:D3}";
            
            _ordenes.Add(entity);

        }

        public void Delete(OrdenLaboratorio entity)
        {
            _ordenes.Remove(entity);
        }

        public List<OrdenLaboratorio> GetAll()
        {
            return _ordenes;
        }

        public List<OrdenLaboratorio> GetOrdenLaboratorioByArea(Area area, DateTime fecha)
        {
            return _ordenes.FindAll(x => x.Area == area && x.FechaProgramada == fecha);

        }

        public List<OrdenLaboratorio> GetOrdenLaboratorioByFecha(DateTime fecha)
        {
            return _ordenes.FindAll(x => x.FechaProgramada == fecha);
        }

        public OrdenLaboratorio GetOrdenLaboratorioById(string id)
        {
            return _ordenes.FirstOrDefault(x => x.IdOrden == id);
        }

        public List<OrdenLaboratorio> GetOrdenLaboratorioByIdMedico(string idmedico)
        {
            return _ordenes.FindAll(x => x.IdMedico == idmedico); ;
        }

        public List<OrdenLaboratorio> GetOrdenLaboratorioByIdPaciente(string idpaciente)
        {
            return _ordenes.FindAll(x => x.IdPaciente == idpaciente);
        }

        public List<OrdenLaboratorio> GetOrdenLaboratorioByServicio(Servicio servicio, DateTime fecha)
        {
            return _ordenes.FindAll(x => x.Servicio == servicio && x.FechaProgramada == fecha);
        }

        public void Update(OrdenLaboratorio entity)
        {
            
        }
    }
}

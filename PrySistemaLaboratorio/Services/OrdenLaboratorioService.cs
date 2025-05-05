using PrySistemaLaboratorio.Models;
using PrySistemaLaboratorio.Reposotories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Services
{
    internal class OrdenLaboratorioService : IOrdenLaboratorioService
    {
        private readonly IOrdenLaboratorioRepositorio _ordenLaboratorioRepositorio;

        public OrdenLaboratorioService(IOrdenLaboratorioRepositorio ordenLaboratorioRepositorio)
        {
            this._ordenLaboratorioRepositorio = ordenLaboratorioRepositorio;
        }

        public bool CrearOrden(OrdenLaboratorio orden)
        {
            _ordenLaboratorioRepositorio.Add(orden);
        }

        public List<OrdenLaboratorio> GetOrdenLaboratorioByArea(Area area, DateTime fecha)
        {
            return _ordenLaboratorioRepositorio.GetOrdenLaboratorioByArea(area,fecha)
        }

        public List<OrdenLaboratorio> GetOrdenLaboratorioByFecha(DateTime fecha)
        {
            return _ordenLaboratorioRepositorio.GetOrdenLaboratorioByFecha(fecha);
        }

        public OrdenLaboratorio GetOrdenLaboratorioById(string id)
        {
            return _ordenLaboratorioRepositorio.GetOrdenLaboratorioById(id);
        }

        public List<OrdenLaboratorio> GetOrdenLaboratorioByIdMedico(string idmedico)
        {
            return _ordenLaboratorioRepositorio.GetOrdenLaboratorioByIdMedico(idmedico);
        }

        public List<OrdenLaboratorio> GetOrdenLaboratorioByIdPaciente(string idpaciente)
        {
            return _ordenLaboratorioRepositorio.GetOrdenLaboratorioByIdPaciente(idpaciente);
        }

        public List<OrdenLaboratorio> GetOrdenLaboratorioByServicio(Servicio servicio, DateTime fecha)
        {
            return _ordenLaboratorioRepositorio.GetOrdenLaboratorioByServicio(servicio, fecha);
        }
    } 
}

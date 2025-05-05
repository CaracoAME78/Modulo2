using PrySistemaLaboratorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Services
{
    internal interface IOrdenLaboratorioService
    {
        bool CrearOrden(OrdenLaboratorio orden);
        OrdenLaboratorio GetOrdenLaboratorioById(string id);
        List<OrdenLaboratorio> GetOrdenLaboratorioByArea(Area area, DateTime fecha);
        List<OrdenLaboratorio> GetOrdenLaboratorioByServicio(Servicio servicio, DateTime fecha);
        List<OrdenLaboratorio> GetOrdenLaboratorioByIdMedico(string idmedico);
        List<OrdenLaboratorio> GetOrdenLaboratorioByIdPaciente(string idpaciente);
        List<OrdenLaboratorio> GetOrdenLaboratorioByFecha(DateTime fecha);

    }
}

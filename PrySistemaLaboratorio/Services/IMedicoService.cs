using PrySistemaLaboratorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Services
{
    internal interface IMedicoService
    {
        bool CrearMedico(Medico medico);
        Medico GetMedicoById(string id);
        List<Medico> GetMedicos();
        Paciente GetMedicoByDni(string dni);
        
    }
}

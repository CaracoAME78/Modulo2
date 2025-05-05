using PrySistemaLaboratorio.Models;
using PrySistemaLaboratorio.Reposotories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Reposotories
{
    internal interface IPacienteRepositorio : IRepositorio<Paciente>
    {
        Paciente GetByPhoneNumber(string phoneNumber);
        Paciente GetByEmail(string email);
        Paciente GetByDni(string dni);
        Paciente GetById(string id);

    }
}

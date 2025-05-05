using PrySistemaLaboratorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Services
{
    internal interface IPacienteService
    {
        bool CrearPaciente(Paciente paciente);
        bool ModificarPaciente( Paciente paciente);
        bool EliminarPaciente(Paciente paciente);
        Paciente GetPacienteById(string id);
        List<Paciente> GetPacientes();
        Paciente GetPacienteByDni(string dni);
        Paciente GetPacienteByEmail(string email);
        Paciente GetPacienteByPhoneNumber(string phoneNumber);
        
    }
}

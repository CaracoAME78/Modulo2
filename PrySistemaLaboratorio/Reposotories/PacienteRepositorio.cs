using PrySistemaLaboratorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Reposotories
{
    internal class PacienteRepositorio : IPacienteRepositorio
    {
        private List<Paciente> _pacientes = new List<Paciente>();
        private static Dictionary<string, int> correlativos = new Dictionary<string, int>();
       


        public Paciente GetById(String id)
        {
            return _pacientes.FirstOrDefault(x => x.Id == id);
        }

        public void Add (Paciente entity)
        {
            string yy = DateTime.Now.ToString("yy");
            string mm = DateTime.Now.ToString("MM");
            string clave = yy + mm;

            if (!correlativos.ContainsKey(clave))
                correlativos[clave] = 1;
            else
                correlativos[clave]++;

            entity.Id =  $"P{yy}{mm}{correlativos[clave].ToString("D3")}";

            _pacientes.Add(entity);
        }

        public void Update (Paciente entity)
        {
            var index = _pacientes.IndexOf(entity);
            if ( index != -1)
            {
                _pacientes[index] = entity;
            }
                
        }

        public void Delete (Paciente entity)
        {
            _pacientes.Remove(entity);
        }

       
        public Paciente GetByDni(string dni)
        {
            return _pacientes.FirstOrDefault(x => x.Dni == dni);

            
        }

        public Paciente GetByEmail(string email)
        {
            return _pacientes.FirstOrDefault( x => x.Correo == email);
            
        }

        public Paciente GetByPhoneNumber(string phoneNumber)
        {
            return _pacientes.FirstOrDefault(x => x.Celular == phoneNumber);

        }
        public List<Paciente> GetAll()
        {
            return _pacientes;
        }
    }
}

﻿using PrySistemaLaboratorio.Models;
using PrySistemaLaboratorio.Reposotories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Services
{
    internal class PacienteService : IPacienteService
    {
        private readonly IPacienteRepositorio _pacienteRepositorio;

        public PacienteService(IPacienteRepositorio pacienteRepositorio)
        {
            this._pacienteRepositorio = pacienteRepositorio;
        }

        public bool CrearPaciente(Paciente paciente)
        {
            try
            {
                _pacienteRepositorio.Add(paciente);
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return false;
            }
        }

        public bool ModificarPaciente( Paciente paciente)
        {
            try
            {
                _pacienteRepositorio.Update(paciente);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool EliminarPaciente(Paciente paciente)
        {
            try
            {
                _pacienteRepositorio.Delete(paciente);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        public Paciente GetPacienteByDni(string dni)
        {
            return _pacienteRepositorio.GetByDni(dni);
        }

        public Paciente GetPacienteByEmail(string email)
        {
            return _pacienteRepositorio.GetByEmail(email);
        }


        public Paciente GetPacienteByPhoneNumber(string phoneNumber)
        {
            return _pacienteRepositorio.GetByPhoneNumber(phoneNumber);
        }

        public List<Paciente> GetPacientes()
        {
            return _pacienteRepositorio.GetAll();
        }

        public Paciente GetPacienteById(string id)
        {
            return _pacienteRepositorio.GetById(id);
        }

    }
}

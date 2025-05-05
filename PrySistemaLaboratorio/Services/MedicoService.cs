using PrySistemaLaboratorio.Models;
using PrySistemaLaboratorio.Reposotories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Services
{
    internal class MedicoService : IMedicoService
    {
        private readonly IMedicoRepositorio _medicoRepositorio;
        public MedicoService(IMedicoRepositorio medicoRepositorio)
        {
            this._medicoRepositorio = medicoRepositorio;
        }
        public bool CrearMedico(Medico medico)
        {
            try
            {
                _medicoRepositorio.Add(medico);
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return false;
            }
        }

        public Medico GetMedicoByDni(string dni)
        {
            return _medicoRepositorio.GetByDni(dni);
        }

        public Medico GetMedicoById(string id)
        {
            return _medicoRepositorio.GetById(id);
        }

        public List<Medico> GetMedicos()
        {
            return _medicoRepositorio.GetAll();
        }

        Paciente IMedicoService.GetMedicoByDni(string dni)
        {
            throw new NotImplementedException();
        }

    }
}

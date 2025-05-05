using PrySistemaLaboratorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Reposotories
{
    internal class MedicoRepositorio : IMedicoRepositorio
    {
        private List<Medico> _medicos = new List<Medico>();
        private static Dictionary<string, int> correlativosMed = new Dictionary<string, int>();

        public MedicoRepositorio()
        {
            string id;
            id= this.GeneraId();
            _medicos.Add(new Medico() { Id = id , Nombres = "Juan", ApellidoPaterno="Garcia", ApellidoMaterno="Lozano", Dni ="40051421", Sexo=Sexo.Masculino, Celular="999999999",Correo="JGarcia@corre.com"});
            id = this.GeneraId();
            _medicos.Add(new Medico() { Id = id, Nombres = "Maria", ApellidoPaterno = "Valcarcel", ApellidoMaterno = "Perez", Dni = "40051420", Sexo = Sexo.Femenino, Celular = "999999888", Correo = "Mvarcal@corre.com" });
            id = this.GeneraId();
            _medicos.Add(new Medico() { Id = id, Nombres = "Jose", ApellidoPaterno = "Espinoza", ApellidoMaterno = "Ramos", Dni = "10051421", Sexo = Sexo.Masculino, Celular = "777999999", Correo = "Jespinoza@corre.com" });
            id = this.GeneraId();
            _medicos.Add(new Medico() { Id = id, Nombres = "Willy", ApellidoPaterno = "Moreno", ApellidoMaterno = "Diaz", Dni = "20051421", Sexo = Sexo.Masculino, Celular = "999555999", Correo = "Wmoreno@corre.com" });
            id = this.GeneraId();
            _medicos.Add(new Medico() { Id = id, Nombres = "Betzabeth", ApellidoPaterno = "Rios", ApellidoMaterno = "Valenzuela", Dni = "10051101", Sexo = Sexo.Femenino, Celular = "994449999", Correo = "Brios@corre.com" });

        }

        public string GeneraId()
        {
            string yy = DateTime.Now.ToString("yy");
            string mm = DateTime.Now.ToString("MM");
            string clave = yy + mm;

            if (!correlativosMed.ContainsKey(clave))
                correlativosMed[clave] = 1;
            else
                correlativosMed[clave]++;

            return $"M{yy}{mm}{correlativosMed[clave].ToString("D3")}";

        }

        public void Add(Medico entity)
        {
            string yy = DateTime.Now.ToString("yy");
            string mm = DateTime.Now.ToString("MM");
            string clave = yy + mm;

            if (!correlativosMed.ContainsKey(clave))
                correlativosMed[clave] = 1;
            else
                correlativosMed[clave]++;

            entity.Id = $"M{yy}{mm}{correlativosMed[clave].ToString("D3")}";

            _medicos.Add(entity);



        }

        public void Delete(Medico entity)
        {
            _medicos.Remove(entity);
        }

        public List<Medico> GetAll()
        {
            return _medicos;
        }

        public Medico GetByDni(string dni)
        {
            return _medicos.FirstOrDefault(x => x.Dni == dni);
        }

        public Medico GetById(string id)
        {
            return _medicos.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Medico entity)
        {
            var index = _medicos.IndexOf(entity);
            if (index != -1)
            {
                _medicos[index] = entity;
            }
        }
    }
}

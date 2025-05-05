using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Models
{
    internal class Medico:Persona
    {
        MedicoEstado Estado { get; set; }
        public Medico()
        {

        }

        public Medico(String id, string nombres, string apePat, string apeMat, DateTime fechaNacimiento, string dni, Sexo sexo, string direccion, string celular, string correo)
        {
            this.Id = id;   
            this.Nombres = nombres;
            this.ApellidoPaterno = apePat;
            this.ApellidoMaterno = apeMat;
            this.FechaNacimiento = fechaNacimiento;
            this.Dni = dni;
            this.Sexo = sexo;
            this.Direccion = direccion;
            this.Celular = celular;
            this.Correo = correo;
            this.Estado = MedicoEstado.Activo;

        }

        public override string ToString()
        {
            return $"=> {Id}  {Nombres}  {ApellidoPaterno} {ApellidoMaterno} {FechaNacimiento}  {Sexo}  {Celular}  {Correo}";
        }
    }
}

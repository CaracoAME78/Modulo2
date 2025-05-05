using PrySistemaLaboratorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Reposotories
{
    internal interface IMedicoRepositorio : IRepositorio<Medico>
    {
        Medico GetByDni(string dni);
        Medico GetById(string id);
    }
}

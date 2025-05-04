using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrySistemaLaboratorio.Util
{
    internal class GeneradorIdPaciente
    {
        private static Dictionary<string, int> correlativos = new Dictionary<string, int>();

        public static string GenerarId()
        {
            string yy = DateTime.Now.ToString("yy");
            string mm = DateTime.Now.ToString("MM");
            string clave = yy + mm;

            if (!correlativos.ContainsKey(clave))
                correlativos[clave] = 1;
            else
                correlativos[clave]++;

            return $"P{yy}{mm}{correlativos[clave].ToString("D3")}";
        }
    }
}

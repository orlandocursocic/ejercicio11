using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class CocinaUtil : ICocinaUtil
    {
        private static bool llamado = false;

        public double PesarAlimento(Alimento alimento)
        {
            return alimento.peso;
        }

        public void CalentarAlimento(Alimento alimento)
        {
            //Not Implemented
            llamado = true;
        }

        public static bool IsLlamado()
        {
            return llamado;
        }
    }
}

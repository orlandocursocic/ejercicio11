using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class Aviso
    {
        public int id { get; set; }
        private static int counter = 0;
        public string descripcion { get; set; }
        public int criticidad { get; set; }

        public Aviso(int criticidad)
        {
            this.id = counter;
            counter++;
            if(criticidad < 1 || criticidad > 5)
            {
                throw new CriticidadNoValidaException();
            } else
            {
                this.criticidad = criticidad;
            }
        }

        public Aviso(int criticidad, string descripcion)
        {
            this.id = counter;
            counter++;
            if (criticidad < 1 || criticidad > 5)
            {
                throw new CriticidadNoValidaException();
            }
            else
            {
                this.criticidad = criticidad;
            }
            this.criticidad = criticidad;
        }
    }
}

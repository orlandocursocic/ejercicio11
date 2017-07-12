using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class Alimento
    {
        public double peso { get; set; }
        public string nombre { get; set; }
        public bool caliente;

        public Alimento(double peso)
        {
            this.peso = peso;
            this.caliente = false;
        }

        public Alimento(string nombre, double peso)
        {
            this.nombre = nombre;
            this.peso = peso;
            this.caliente = false;
        }

        public bool isCaliente()
        {
            return this.caliente;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            if (((Alimento)obj).nombre == null)
            {
                if (this.nombre != null)
                    return false;
            }
            else
            {
                if (!((Alimento)obj).nombre.Equals(this.nombre))
                {
                    return false;
                }
            }
            return ((Alimento)obj).peso == this.peso;
        }

    }
}

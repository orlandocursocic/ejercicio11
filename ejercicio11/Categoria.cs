using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class Categoria
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public Categoria(string nombre) {
            this.nombre = nombre;
        }

        public Categoria(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
    }
}

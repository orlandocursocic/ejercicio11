using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class Receta
    {
        public string nombre { get; set; }
        public Categoria categoria { get; set; }
        public Alimento alimento1 { get; set; }
        public Alimento alimento2 { get; set; }

        public Receta(string nombre, Alimento alimento1, Alimento alimento2)
        {
            this.nombre = nombre;
            this.alimento1 = alimento1;
            this.alimento2 = alimento2;
        }

        public Receta(string nombre, Alimento alimento1, Alimento alimento2, Categoria categoria)
        {
            this.nombre = nombre;
            this.categoria = categoria;
            this.alimento1 = alimento1;
            this.alimento2 = alimento2;
        }
    }
}

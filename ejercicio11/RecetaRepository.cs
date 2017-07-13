using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class RecetaRepository : IRecetaRepository
    {
        public static IList<Receta> listaRecetas { get; set; }

        public RecetaRepository()
        {
            listaRecetas = new List<Receta>();
        }

        public Receta addReceta(Receta receta)
        {
            // Muy dummie, sin comprobaciones de si existe ni nada
            listaRecetas.Add(receta);
            return receta;
        }
    }
}

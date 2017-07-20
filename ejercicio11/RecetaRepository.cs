using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class RecetaRepository : IRecetaRepository
    {
        public static List<Receta> listaRecetas { get; set; }

        public RecetaRepository()
        {
            listaRecetas = new List<Receta>();
        }

        public Receta addReceta(Receta receta)
        {
            listaRecetas.Add(receta);
            return receta;
        }

        public Receta deleteReceta(Receta receta)
        {
            listaRecetas.Remove(receta);
            return receta;
        }

        public Receta updateReceta(Receta receta)
        {
            //TODO
            return null;
        }

        public Receta getReceta(string nombreReceta)
        {
            //TODO
            return null;
        }

        public List<Receta> listRecetas()
        {
            return listaRecetas;
        }

        //TODO No se me ocurre como retornar una receta sin incluir logica dentro de esta propia clase. Por lo
        // tanto tampoco se me ocurre como hacer el update
    }
}

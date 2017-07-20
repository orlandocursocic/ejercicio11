using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public static List<Categoria> listaCategorias { get; set; }

        public CategoriaRepository()
        {
            listaCategorias = new List<Categoria>();
        }

        public Categoria addCategoria(Categoria categoria)
        {
            listaCategorias.Add(categoria);
            return categoria;
        }

        public Categoria deleteCategoria(Categoria categoria)
        {
            listaCategorias.Remove(categoria);
            return categoria;
        }

        public Categoria updateCategoria(Categoria categoria)
        {
            //TODO
            return null;
        }

        public Receta getCategoria(string nombreCategoria)
        {
            //TODO
            return null;
        }

        public List<Categoria> listCategorias()
        {
            return listaCategorias;
        }

        //TODO No se me ocurre como retornar una receta sin incluir logica dentro de esta propia clase. Por lo
        // tanto tampoco se me ocurre como hacer el update
    }
}

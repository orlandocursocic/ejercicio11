using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class CategoriaService : ICategoriaService
    {
        public ICategoriaRepository categoriaRepository { get; set; }

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public void addCategoria(Categoria categoria)
        {
            Categoria categoriaAux = buscaCategoria(categoria.nombre);

            if (categoriaAux != null)
            {
                throw new CategoriaYaExisteException();
            }
            else
            {
                categoriaRepository.addCategoria(categoria);
            }
        }

        public void updateCategoria(Categoria categoria)
        {
            Categoria categoriaAux = buscaCategoria(categoria.nombre);

            if (categoriaAux != null)
            {
                // TODO implementar correctamente el update de avisoRepository
                categoriaRepository.updateCategoria(categoria);
            }
            else
            {
                throw new CategoriaNoExisteException();
            }
        }

        public void deleteCategoria(Categoria categoria)
        {
            Categoria categoriaAux = buscaCategoria(categoria.nombre);

            if (categoriaAux != null)
            {
                categoriaRepository.deleteCategoria(categoria);
            }
            else
            {
                throw new CategoriaNoExisteException();
            }
        }

        public Categoria categoria(string nombreCategoria)
        {
            Categoria categoriaAux = buscaCategoria(nombreCategoria);

            if (categoriaAux == null)
            {
                throw new CategoriaNoExisteException();
            }

            return categoriaAux;
        }

        public IList<Categoria> listCategorias()
        {
            return categoriaRepository.listCategorias();
        }

        private Categoria buscaCategoria(string nombreReceta)
        {
            IList<Categoria> listaCategorias = categoriaRepository.listCategorias();
            Categoria categoriaAux = null;

            bool bFound = false;
            int i = 0;
            while (!bFound && i < listaCategorias.Count())
            {
                if (listaCategorias.ElementAt(i).nombre.Equals(nombreReceta))
                {
                    bFound = true;
                    categoriaAux = listaCategorias.ElementAt(i);
                }
                i++;
            }
            return categoriaAux;
        }
    }
}

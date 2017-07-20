using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class RecetaService : IRecetaService
    {
        public IRecetaRepository recetaRepository { get; set; }
        public ICategoriaService categoriaService { get; set; }

        public RecetaService(IRecetaRepository recetaRepository, ICategoriaService categoriaService)
        {
            this.recetaRepository = recetaRepository;
            this.categoriaService = categoriaService;
        }

        public void addReceta(Receta receta)
        {
            Receta recetaAux = buscaReceta(receta.nombre);
            Categoria categoriaAux = categoriaService.categoria(receta.categoria.nombre);

            // Si la categoria no existe en la BD
            if (categoriaAux == null)
            {
                throw new CategoriaNoExisteException();
            }

            //Si la receta ya existe en la BD
            if (recetaAux != null)
            {
                throw new RecetaYaExisteException();
            }
            else
            {
                recetaRepository.addReceta(receta);
            }
        }

        public void updateReceta(Receta receta)
        {
            Receta recetaAux = buscaReceta(receta.nombre);

            if (recetaAux != null)
            {
                // TODO implementar correctamente el update de recetaRepository
                recetaRepository.updateReceta(receta);
            }
            else
            {
                throw new CategoriaNoExisteException();
            }
        }

        public void deleteReceta(Receta receta)
        {
            Receta recetaAux = buscaReceta(receta.nombre);

            if (recetaAux != null)
            {
                recetaRepository.deleteReceta(receta);
            }
            else
            {
                throw new CategoriaNoExisteException();
            }
        }

        public Receta receta(string nombreReceta)
        {
            Receta recetaAux = buscaReceta(nombreReceta);

            if (recetaAux == null)
            {
                throw new CategoriaNoExisteException();
            }

            return recetaAux;
        }

        public IList<Receta> listReceta()
        {
            return recetaRepository.listRecetas();
        }

        private Receta buscaReceta(string nombreReceta)
        {
            IList<Receta> listaRecetas = recetaRepository.listRecetas();
            Receta recetaAux = null;

            bool bFound = false;
            int i = 0;
            while (!bFound && i < listaRecetas.Count())
            {
                if (listaRecetas.ElementAt(i).nombre.Equals(nombreReceta))
                {
                    bFound = true;
                    recetaAux = listaRecetas.ElementAt(i);
                }
                i++;
            }
            return recetaAux;
        }
    }
}

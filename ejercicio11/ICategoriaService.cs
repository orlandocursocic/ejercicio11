using System.Collections.Generic;

namespace ejercicio11
{
    public interface ICategoriaService
    {
        ICategoriaRepository categoriaRepository { get; set; }

        void addCategoria(Categoria categoria);
        Categoria categoria(string nombreCategoria);
        void deleteCategoria(Categoria categoria);
        IList<Categoria> listCategorias();
        void updateCategoria(Categoria categoria);
    }
}
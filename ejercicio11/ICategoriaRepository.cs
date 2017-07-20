using System.Collections.Generic;

namespace ejercicio11
{
    public interface ICategoriaRepository
    {
        Categoria addCategoria(Categoria categoria);
        Categoria deleteCategoria(Categoria categoria);
        Receta getCategoria(string nombreCategoria);
        List<Categoria> listCategorias();
        Categoria updateCategoria(Categoria categoria);
    }
}
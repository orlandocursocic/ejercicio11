using System.Collections.Generic;

namespace ejercicio11
{
    public interface IRecetaRepository
    {
        Receta addReceta(Receta receta);
        Receta deleteReceta(Receta receta);
        Receta updateReceta(Receta receta);
        Receta getReceta(string nombreReceta);
        List<Receta> listRecetas();

    }
}
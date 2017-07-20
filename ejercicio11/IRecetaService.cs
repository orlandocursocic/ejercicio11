using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public interface IRecetaService
    {
        IRecetaRepository recetaRepository { get; set; }

        void updateReceta(Receta receta);
        void addReceta(Receta receta);
        void deleteReceta(Receta receta);
        Receta receta(string nombreReceta);
        IList<Receta> listReceta();
    }
}

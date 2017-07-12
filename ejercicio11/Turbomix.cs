using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class Turbomix
    {
        public ICocinaUtil cocinaUtil { get; set; }

        public Turbomix(ICocinaUtil cocinaUtil)
        {
            this.cocinaUtil = cocinaUtil;
        }

        /// <summary>
        /// Retorna null si no se puede realizar el plato, ya sea porque no tiene los alimentos
        /// necesarios o porque los recibe calientes
        /// </summary>
        /// <param name="alimento1"> Alimento 1 a cocinar</param>
        /// <param name="alimento2"> Alimento 2 a cocinar</param>
        /// <param name="receta"> Receta a seguir</param>
        /// <returns>El plato si se pudo cocinar o null si no se pudo</returns>
        public Plato CocinarReceta(Alimento alimento1, Alimento alimento2, Receta receta)
        {
            Plato plato;

            if(isCookable(alimento1, alimento2, receta))
            {
				cocinaUtil.CalentarAlimento(alimento1);
				cocinaUtil.CalentarAlimento(alimento2);

				alimento1.peso = receta.alimento1.peso;
				alimento1.peso = receta.alimento1.peso;

				plato = new Plato(alimento1, alimento2);
            } else
            {
                plato = null;
            }

            return plato;
        }

        private bool isCookable (Alimento alimento1, Alimento alimento2, Receta receta){
            bool bCooked = false;

            if (alimento1.isCaliente() || alimento2.isCaliente())
            {
                bCooked = false;
            }
            else if (alimento1.nombre.Equals(receta.alimento1.nombre) ||
                     alimento2.nombre.Equals(receta.alimento2.nombre))
            {
                bCooked = false;
            }
            else if (cocinaUtil.PesarAlimento(alimento1) < receta.alimento1.peso ||
                     cocinaUtil.PesarAlimento(alimento2) < receta.alimento2.peso)
            {
                bCooked = false;
            }
            else
            {
                bCooked = true;
            }
            return bCooked;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class Turbomix : ITurbomix
    {
        public ICocinaUtilService cocinaUtilService { get; set; }
        public IRecetaService recetaService { get; set; }

        public Turbomix(ICocinaUtilService cocinaUtil, IRecetaService recetaService)
        {
            this.cocinaUtilService = cocinaUtil;
            this.recetaService = recetaService;
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

            if (isCookable(alimento1, alimento2, receta))
            {
                alimento1.peso = receta.alimento1.peso;
                alimento1.peso = receta.alimento1.peso;

                cocinaUtilService.CalentarAlimento(alimento1);
                cocinaUtilService.CalentarAlimento(alimento2);

                plato = new Plato(alimento1, alimento2);
            }
            else
            {
                plato = null;
            }

            return plato;
        }

        /// <summary>
        /// Comprueba si los alimentos pueden ser cocinados siguiendo la receta tal y como
        /// indican los requisitos actuales (12/07/2017)
        /// </summary>
        /// <param name="alimento1"> Alimento a cocinar</param>
        /// <param name="alimento2">Alimento a cocinar</param>
        /// <param name="receta">Receta a seguir</param>
        /// <returns>true si se puede cocinar o false en caso contrario</returns>
        private bool isCookable(Alimento alimento1, Alimento alimento2, Receta receta)
        {
            bool bCookable = true;

            if (alimento1 == null || alimento2 == null || receta == null)
            {
                bCookable = false;
            }
            else if (!alimento1.nombre.Equals(receta.alimento1.nombre) ||
                 !alimento2.nombre.Equals(receta.alimento2.nombre))
            {
                bCookable = false;
            }
            else if (alimento1.isCaliente() || alimento2.isCaliente())
            {
                bCookable = false;
            }
            else if (cocinaUtilService.PesarAlimento(alimento1) < receta.alimento1.peso ||
                     cocinaUtilService.PesarAlimento(alimento2) < receta.alimento2.peso)
            {
                bCookable = false;
            }

            return bCookable;
        }

        public void addRecetaRepositorio(Receta receta)
        {
            this.recetaService.addReceta(receta);
        }
    }
}
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

        public Plato CocinarPlato(Alimento alimento1, Alimento alimento2)
        {
            cocinaUtil.PesarAlimento(alimento1);
            cocinaUtil.CalentarAlimento(alimento1);
            cocinaUtil.PesarAlimento(alimento2);
            cocinaUtil.CalentarAlimento(alimento2);

            return new Plato(alimento1, alimento2);
        }
    }
}

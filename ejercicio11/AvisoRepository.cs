using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class AvisoRepository : IAvisoRepository
    {
        public static List<Aviso> listaAvisos { get; set; }

        public AvisoRepository()
        {
            listaAvisos = new List<Aviso>();
        }

        public Aviso addAviso(Aviso aviso)
        {
            listaAvisos.Add(aviso);
            return aviso;
        }

        public Aviso deleteAviso(Aviso aviso)
        {
            listaAvisos.Remove(aviso);
            return aviso;
        }

        public Aviso updateAviso(Aviso aviso)
        {
            //TODO
            return null;
        }

        public Aviso getAviso(int id)
        {
            //TODO
            return null;
        }

        public List<Aviso> listAvisos()
        {
            return listaAvisos;
        }

        //TODO No se me ocurre como retornar un aviso sin incluir logica dentro de esta propia clase. Por lo
        // tanto tampoco se me ocurre como hacer el update
    }
}

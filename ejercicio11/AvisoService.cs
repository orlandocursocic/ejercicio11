using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11
{
    public class AvisoService : IAvisoService
    {
        public IAvisoRepository avisosRepository { get; set; }

        public AvisoService(IAvisoRepository avisosRepository)
        {
            this.avisosRepository = avisosRepository;
        }

        public void addAviso(Aviso aviso)
        {
            Aviso avisoAux = buscaAviso(aviso.id);

            if (avisoAux != null)
            {
                throw new AvisoYaExisteException();
            }
            else
            {
                avisosRepository.addAviso(aviso);
            }
        }

        public void updateAviso(Aviso aviso)
        {
            Aviso avisoAux = buscaAviso(aviso.id);

            if (avisoAux != null)
            {
                // TODO implementar correctamente el update de avisoRepository
                avisosRepository.updateAviso(aviso);
            }
            else
            {
                throw new AvisoNoExisteException();
            }
        }

        public void deleteAviso(Aviso aviso)
        {
            Aviso avisoAux = buscaAviso(aviso.id);

            if (avisoAux != null)
            {
                avisosRepository.deleteAviso(aviso);
            }
            else
            {
                throw new AvisoNoExisteException();
            }
        }

        public Aviso aviso(int id)
        {
            Aviso avisoAux = buscaAviso(id);

            if (avisoAux == null)
            {
                throw new AvisoNoExisteException();
            }
            return avisoAux;
        }

        public IList<Aviso> listAvisos()
        {
            return avisosRepository.listAvisos();
        }

        private Aviso buscaAviso(int id)
        {
            IList<Aviso> listaAvisos = avisosRepository.listAvisos();
            Aviso avisosAux = null;

            bool bFound = false;
            int i = 0;
            while (!bFound && i < listaAvisos.Count())
            {
                if (listaAvisos.ElementAt(i).id == id)
                {
                    bFound = true;
                    avisosAux = listaAvisos.ElementAt(i);
                }
                i++;
            }
            return avisosAux;
        }
    }
}

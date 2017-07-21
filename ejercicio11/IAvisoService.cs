using System.Collections.Generic;

namespace ejercicio11
{
    public interface IAvisoService
    {
        IAvisoRepository avisosRepository { get; set; }

        void addAviso(Aviso aviso);
        Aviso aviso(int id);
        void deleteAviso(Aviso aviso);
        IList<Aviso> listAvisos();
        void updateAviso(Aviso aviso);
    }
}
using System.Collections.Generic;

namespace ejercicio11
{
    public interface IAvisoRepository
    {
        Aviso addAviso(Aviso aviso);
        Aviso deleteAviso(Aviso aviso);
        Aviso getAviso(int id);
        List<Aviso> listAvisos();
        Aviso updateAviso(Aviso aviso);
    }
}
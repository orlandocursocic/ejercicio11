using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ejercicio11;

namespace ejercicio11Test
{
    [TestClass]
    public class TurbomixTest
    {
        private Alimento alimento1;
        private Alimento alimento2;
        private Turbomix sut;

        [TestInitialize]
        public void InitTest()
        {
            alimento1 = new Alimento(200.0);
            alimento2 = new Alimento(200.0);
            sut = new Turbomix(new CocinaDeJuguete());
        }

        [TestMethod]
        public void CocinarAlimentoTest()
        {
            sut.CocinarPlato(alimento1, alimento2);
        }
    }

    public class CocinaDeJuguete : ICocinaUtil
    {
        public void CalentarAlimento(Alimento alimento)
        {           
        }

        public double PesarAlimento(Alimento alimento)
        {
            return 200.0;
        }
    }
}

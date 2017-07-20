using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ejercicio11;

namespace ejercicio11Test
{
    [TestClass]
    public class CocinaUtilServiceTest
    {
        private Alimento alimento1;
        private ICocinaUtilService sut;

        [TestInitialize]
        public void InitTest()
        {
            alimento1 = new Alimento(500.0);
            sut = new CocinaUtilService();
        }

        [TestMethod]
        public void PesarAlimentoTest()
        {
            double resultado = sut.PesarAlimento(alimento1);

            Assert.AreEqual(resultado, 500.0);
        }

        [TestMethod]
        public void CalentarAlimentoTest()
        {
            sut.CalentarAlimento(alimento1);

            Assert.IsTrue(CocinaUtilService.IsLlamado());
        }
    }
}

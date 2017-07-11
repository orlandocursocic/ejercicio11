using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ejercicio11;

namespace ejercicio11Test
{
    [TestClass]
    public class CocinaUtilTest
    {
        private Alimento alimento1;
        private CocinaUtil sut;

        [TestInitialize]
        public void InitTest()
        {
            alimento1 = new Alimento(500.0);
            sut = new CocinaUtil();
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

            Assert.IsTrue(CocinaUtil.IsLlamado());
        }
    }
}

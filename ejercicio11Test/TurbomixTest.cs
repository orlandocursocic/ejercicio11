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
        private Alimento alimentoReceta1;
        private Alimento alimentoReceta2;
        private Receta receta;
        private Turbomix sut;

        [TestInitialize]
        public void InitTest()
        {
            alimento1 = new Alimento("Curry", 200.0);
            alimento2 = new Alimento("Queso", 200.0);
            alimentoReceta1 = new Alimento("Curry", 155.5);
            alimentoReceta2 = new Alimento("Queso", 199.9);
            receta = new Receta(alimentoReceta1, alimentoReceta2);

            sut = new Turbomix(new CocinaDeJuguete());
        }

        [TestMethod]
        public void CocinarRecetaTest()
        {
            Plato plato = sut.CocinarReceta(alimento1, alimento2, receta);

            Assert.AreNotEqual(null, plato);
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

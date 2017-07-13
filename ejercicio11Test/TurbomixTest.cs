using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ejercicio11;
using Moq;

namespace ejercicio11Test
{
    [TestClass]
    public class TurbomixTest
    {
        private Alimento alimento1;
        private Alimento alimento2;
        private Alimento alimentoReceta1;
        private Alimento alimentoReceta2;
        private Alimento alimentoReceta3;
        private Receta receta;
        private Receta receta2;
        private Turbomix sut;

        [TestInitialize]
        public void InitTest()
        {
            alimento1 = new Alimento("Curry", 200.0);
            alimento2 = new Alimento("Queso", 200.0);
            alimentoReceta1 = new Alimento("Curry", 155.5);
            alimentoReceta2 = new Alimento("Queso", 199.9);
            alimentoReceta3 = new Alimento("Chocolate", 2000.99);
            receta = new Receta(alimentoReceta1, alimentoReceta2);
            receta2 = new Receta(alimentoReceta2, alimentoReceta3);

            // Se ha sustituido la cocina de juguete (Dummie) por CocinaUtil
            sut = new Turbomix(new CocinaUtil());
        }

        [TestMethod]
        public void CocinarRecetaMockTest()
        {
            var mockCocinautil = new Mock<ICocinaUtil>();
            ICocinaUtil cocinaUtil = mockCocinautil.Object;

            mockCocinautil.Setup(bascula => bascula.PesarAlimento(It.IsAny<Alimento>()))
                .Returns((Alimento p) => p.peso);
            mockCocinautil.Setup(bascula => bascula.PesarAlimento(It.IsAny<Alimento>()))
                .Returns((Alimento p) => p.peso);

            mockCocinautil.Setup(cocina => cocina.CalentarAlimento(It.IsAny<Alimento>()))
                .Callback((Alimento p1) => p1.caliente = true);
            mockCocinautil.Setup(cocina => cocina.CalentarAlimento(It.IsAny<Alimento>()))
                .Callback((Alimento p1) => p1.caliente = true);

            sut = new Turbomix(cocinaUtil);

            Plato plato = sut.CocinarReceta(alimento1, alimento2, receta);

            mockCocinautil.Verify(bascula => bascula.PesarAlimento(It.IsAny<Alimento>()), Times.AtLeast(2));
            mockCocinautil.Verify(cocina => cocina.CalentarAlimento(It.IsAny<Alimento>()), Times.Exactly(2));
        }

        [TestMethod]
        public void CocinarRecetaTest()
        {
            Plato plato = sut.CocinarReceta(alimento1, alimento2, receta);

            Assert.AreNotEqual(null, plato);
        }

        [TestMethod]
        public void CocinarRecetaNombreAlimentoErroneoTest()
        {
            alimento1.nombre = "UnoQueNoVale";

            Plato plato = sut.CocinarReceta(alimento1, alimento2, receta);

            Assert.IsNull(plato);
        }

        [TestMethod]
        public void CocinarRecetaAlimentoCalienteTest()
        {
            alimento1.caliente = true;

            Plato plato = sut.CocinarReceta(alimento1, alimento2, receta);

            Assert.IsNull(plato);
        }

        [TestMethod]
        public void CocinarRecetaPesoMenorTest()
        {
            alimento1.peso = 0.0;

            Plato plato = sut.CocinarReceta(alimento1, alimento2, receta);

            Assert.IsNull(plato);
        }

        [TestMethod]
        public void AddRecetaTest()
        {
            var mockRecetaRepository = new Mock<IRecetaRepository>();
            IRecetaRepository recetaRepository = mockRecetaRepository.Object;

            mockRecetaRepository.Setup(Turbomix => Turbomix.addReceta(It.IsAny<Receta>()))
                .Returns((Receta r) => r);
            mockRecetaRepository.Setup(Turbomix => Turbomix.addReceta(It.IsAny<Receta>()))
                .Returns((Receta r) => r);

            sut = new Turbomix(new CocinaUtil(), recetaRepository);

            sut.addRecetaRepositorio(receta);
            sut.addRecetaRepositorio(receta2);

            mockRecetaRepository.Verify(Turbomix => Turbomix.addReceta(It.IsAny<Receta>()), Times.AtLeast(2));
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

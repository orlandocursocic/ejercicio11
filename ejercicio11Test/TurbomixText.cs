using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ejercicio11;
using Microsoft.Practices.Unity;
using Moq;

namespace ejercicio11Test
{
    [TestClass]
    public class TurbomixText
    {
        private Alimento alimento1;
        private Alimento alimento2;
        private Alimento alimentoReceta1;
        private Alimento alimentoReceta2;
        private Alimento alimentoReceta3;
        private string nombreReceta1;
        private string nombreReceta2;
        private Receta receta;
        private Receta receta2;

        private ITurbomix sut;

        [TestInitialize]
        public void InitTest()
        {
            alimento1 = new Alimento("Curry", 200.0);
            alimento2 = new Alimento("Queso", 200.0);
            alimentoReceta1 = new Alimento("Curry", 155.5);
            alimentoReceta2 = new Alimento("Queso", 199.9);
            alimentoReceta3 = new Alimento("Chocolate", 2000.99);
            nombreReceta1 = "nombreReceta1";
            nombreReceta2 = "nombreReceta2";
            receta = new Receta(nombreReceta1, alimentoReceta1, alimentoReceta2);
            receta2 = new Receta(nombreReceta2, alimentoReceta2, alimentoReceta3);
        }

        [TestMethod]
        public void CocinarRecetaMockTest()
        {
            var mockCocinautilService = new Mock<ICocinaUtilService>();
            ICocinaUtilService cocinaUtilService = mockCocinautilService.Object;

            var mockRecetaService = new Mock<IRecetaService>();
            IRecetaService recetaService = mockRecetaService.Object;

            mockCocinautilService.Setup(bascula => bascula.PesarAlimento(It.IsAny<Alimento>()))
                .Returns((Alimento p) => p.peso);
            mockCocinautilService.Setup(bascula => bascula.PesarAlimento(It.IsAny<Alimento>()))
                .Returns((Alimento p) => p.peso);

            mockCocinautilService.Setup(cocina => cocina.CalentarAlimento(It.IsAny<Alimento>()))
                .Callback((Alimento p1) => p1.caliente = true);
            mockCocinautilService.Setup(cocina => cocina.CalentarAlimento(It.IsAny<Alimento>()))
                .Callback((Alimento p1) => p1.caliente = true);

            sut = new Turbomix(cocinaUtilService, recetaService);

            Plato plato = sut.CocinarReceta(alimento1, alimento2, receta);

            mockCocinautilService.Verify(bascula => bascula.PesarAlimento(It.IsAny<Alimento>()), Times.AtLeast(2));
            mockCocinautilService.Verify(cocina => cocina.CalentarAlimento(It.IsAny<Alimento>()), Times.Exactly(2));
        }

        [TestMethod]
        public void AddRecetaTest()
        {
            var mockRecetaService = new Mock<IRecetaService>();
            IRecetaService recetaService = mockRecetaService.Object;

            var mockCocinaUtilService = new Mock<ICocinaUtilService>();
            ICocinaUtilService cocinaUtilService = mockCocinaUtilService.Object;

            mockRecetaService.Setup(Turbomix => Turbomix.addReceta(It.IsAny<Receta>()));
            mockRecetaService.Setup(Turbomix => Turbomix.addReceta(It.IsAny<Receta>()));

            sut = new Turbomix(cocinaUtilService, recetaService);

            sut.addRecetaRepositorio(receta);
            sut.addRecetaRepositorio(receta2);

            mockRecetaService.Verify(Turbomix => Turbomix.addReceta(It.IsAny<Receta>()), Times.AtLeast(2));
        }
    }
}

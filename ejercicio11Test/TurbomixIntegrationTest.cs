using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ejercicio11;
using Moq;
using Microsoft.Practices.Unity;

namespace ejercicio11Test
{
    [TestClass]
    public class TurbomixIntegrationTest
    {
        IUnityContainer container;

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
            container = new UnityContainer();
            container.RegisterType<ITurbomix, Turbomix>();
            container.RegisterType<ICocinaUtilService, CocinaUtilService>();
            container.RegisterType<IRecetaService, ejercicio11.RecetaService>();
            container.RegisterType<IRecetaRepository, RecetaRepository>();
            container.RegisterType<ICategoriaService, CategoriaService>();
            container.RegisterType<ICategoriaRepository, CategoriaRepository>();

            alimento1 = new Alimento("Curry", 200.0);
            alimento2 = new Alimento("Queso", 200.0);
            alimentoReceta1 = new Alimento("Curry", 155.5);
            alimentoReceta2 = new Alimento("Queso", 199.9);
            alimentoReceta3 = new Alimento("Chocolate", 2000.99);
            nombreReceta1 = "nombreReceta1";
            nombreReceta2= "nombreReceta2";
            receta = new Receta(nombreReceta1, alimentoReceta1, alimentoReceta2);
            receta2 = new Receta(nombreReceta2, alimentoReceta2, alimentoReceta3);

            sut = container.Resolve<ITurbomix>();
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

    }

    // Clase dummie para tests. Realizada previo al aprendizaje de mocks
    public class CocinaDeJuguete : ICocinaUtilService
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
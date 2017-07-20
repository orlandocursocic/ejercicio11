using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ejercicio11;
using Moq;
using System.Collections.Generic;

namespace ejercicio11Test
{
    [TestClass]
    public class RecetaServiceTest
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
        private Categoria categoria1;
        private Categoria categoria2;

        private IRecetaService sut;

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
            categoria1 = new Categoria("Primero", "Se trata de un primer plato");
            categoria2 = new Categoria("Segundo", "Se trata de un segundo plato");
            receta = new Receta(nombreReceta1, alimentoReceta1, alimentoReceta2, categoria1);
            receta2 = new Receta(nombreReceta2, alimentoReceta2, alimentoReceta3, categoria2);
        }

        [TestMethod]
        public void AddRecetaMockTest()
        {
            var mockRecetaRepository = new Mock<IRecetaRepository>();
            IRecetaRepository recetaRepository = mockRecetaRepository.Object;

            var mockCategoriaService = new Mock<ICategoriaService>();
            ICategoriaService categoriaService = mockCategoriaService.Object;

            mockRecetaRepository.Setup(receta => receta.listRecetas()).Returns(() => new List<Receta> { receta });

            mockCategoriaService.Setup(categoria => categoria.categoria(It.IsAny<String>()))
                .Returns(categoria1);

            mockRecetaRepository.Setup(receta => receta.addReceta(receta2));

            sut = new RecetaService(recetaRepository, categoriaService);

            sut.addReceta(receta2);

            mockRecetaRepository.Verify(receta => receta.listRecetas(), Times.Exactly(1));
            mockRecetaRepository.Verify(receta => receta.addReceta(It.IsAny<Receta>()), Times.Exactly(1));
        }

        [TestMethod]
        [ExpectedException(typeof(CategoriaNoExisteException),
            "La categoria de la receta no existe")]
        public void AddRecetaCategoriaNoExisteMockTest()
        {
            var mockRecetaRepository = new Mock<IRecetaRepository>();
            IRecetaRepository recetaRepository = mockRecetaRepository.Object;

            var mockCategoriaService = new Mock<ICategoriaService>();
            ICategoriaService categoriaService = mockCategoriaService.Object;

            mockRecetaRepository.Setup(receta => receta.listRecetas()).Returns(() => new List<Receta> { receta });

            mockCategoriaService.Setup(categoria => categoria.categoria(It.IsAny<String>()))
                .Returns((Categoria)null);

            sut = new RecetaService(recetaRepository, categoriaService);

            sut.addReceta(receta2);
        }

        [TestMethod]
        [ExpectedException(typeof(RecetaYaExisteException),
            "La receta ya existe")]
        public void AddRecetaYaExisteMockTest()
        {
            var mockRecetaRepository = new Mock<IRecetaRepository>();
            IRecetaRepository recetaRepository = mockRecetaRepository.Object;

            var mockCategoriaService = new Mock<ICategoriaService>();
            ICategoriaService categoriaService = mockCategoriaService.Object;

            mockRecetaRepository.Setup(receta => receta.listRecetas()).Returns(() => new List<Receta> { receta });

            mockCategoriaService.Setup(categoria => categoria.categoria(It.IsAny<String>()))
                .Returns(categoria1);

            mockRecetaRepository.Setup(recetaSetup => recetaSetup.addReceta(receta));

            sut = new RecetaService(recetaRepository, categoriaService);

            sut.addReceta(receta);
        }
    }
}

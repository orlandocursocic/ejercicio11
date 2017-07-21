using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ejercicio11;
using Moq;
using System.Collections.Generic;

namespace ejercicio11Test
{
    [TestClass]
    public class CategoriaServiceTest
    {
        private Categoria categoria1;
        private Categoria categoria2;

        private ICategoriaService sut;

        [TestInitialize]
        public void InitTest()
        {
            categoria1 = new Categoria("Primero", "Se trata de un primer plato");
            categoria2 = new Categoria("Segundo", "Se trata de un segundo plato");
        }

        [TestMethod]
        public void AddCategoriaMockTest()
        {
            var mockCategoriaRepository = new Mock<ICategoriaRepository>();
            ICategoriaRepository categoriaRepository = mockCategoriaRepository.Object;

            mockCategoriaRepository.Setup(categoria => categoria.listCategorias()).Returns(() => new List<Categoria> { categoria1 });

            mockCategoriaRepository.Setup(categoria => categoria.addCategoria(categoria2));

            sut = new CategoriaService(categoriaRepository);

            sut.addCategoria(categoria2);

            mockCategoriaRepository.Verify(categoria => categoria.listCategorias(), Times.Exactly(1));
            mockCategoriaRepository.Verify(categoria => categoria.addCategoria(It.IsAny<Categoria>()), Times.Exactly(1));
        }

        [TestMethod]
        [ExpectedException(typeof(CategoriaYaExisteException),
            "La categoria a anyadir ya existe")]
        public void AddCategoriaYaExisteMockTest()
        {
            var mockCategoriaRepository = new Mock<ICategoriaRepository>();
            ICategoriaRepository categoriaRepository = mockCategoriaRepository.Object;

            mockCategoriaRepository.Setup(categoria => categoria.listCategorias()).Returns(() => new List<Categoria> { categoria1 });

            mockCategoriaRepository.Setup(categoria => categoria.addCategoria(categoria1));

            sut = new CategoriaService(categoriaRepository);

            sut.addCategoria(categoria1);
        }
    }
}
